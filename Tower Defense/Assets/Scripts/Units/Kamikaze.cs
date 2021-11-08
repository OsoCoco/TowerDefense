using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum KamikazeState
{
    START,
    SEEK,
    EXPLODE,
}
public class Kamikaze : Unit
{
    [SerializeField]
    KamikazeState myState;

    [SerializeField]
    TreeD<KamikazeState> myTree;
    
    Transform actualTarget;

    [SerializeField]
    LayerMask enemiesMask;

    [SerializeField]
    Collider2D[] enemies;

    #region UNITYFUNCS

    private void Start()
    {
        steering.position = this.transform;
        myState = KamikazeState.START;
    }

    private void Update()
    {
        Perception();
        ChooseAction();
    }
    #endregion

    #region TREEOPS
    void ChoseLowestCostNode()
    {
        Node<KamikazeState> nodoDes;

        List<int> costList = new List<int>();

        foreach (Node<KamikazeState> n in myTree.root.children)
        {
            costList.Add(n.cost);
        }


        int minCost = costList.Min();
        int index = costList.IndexOf(minCost);
        nodoDes = myTree.root.children[index];


        myState = myTree.BFS(nodoDes.data).data;

        Debug.Log(myTree.BFS(nodoDes.data).ToString());
        Debug.Log(myTree.BFS(nodoDes.data).cost);

    }

    void ChangeNodeCost(KamikazeState state, int value)
    {
        Node<KamikazeState> node = myTree.BFS(state);
        node.cost = value;
    }
    #endregion

    #region BEHAVIOUR

    void Perception()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, 3.0f, enemiesMask); 
    }

    void DoSeek()
    {
        if(Vector2.Distance(transform.position,steering.target.position) > 1f)
        {
            steering.doSeek();
        }
        else
        {
            ChangeNodeCost(KamikazeState.EXPLODE, 0);
            ChangeNodeCost(KamikazeState.START, 10);
            ChangeNodeCost(KamikazeState.SEEK, 10);
        }

        ChoseLowestCostNode();
    }

    void DoExplode()
    {
        if(enemies.Length > 0)
        {
            foreach (Collider2D enemie in enemies)
            {
                enemie.GetComponent<Unit>().health -= 2.0f;
            }
        }

        Destroy(this.gameObject,0.5f);
    }

    void ChooseAction()
    {
        switch (myState)
        {
            case KamikazeState.START:
                myState = KamikazeState.SEEK;
                break;
            case KamikazeState.SEEK:

                DoSeek();
                break;
            case KamikazeState.EXPLODE:
                DoExplode();
                break;
            
            default:
                break;
        }
    }

    #endregion
}
