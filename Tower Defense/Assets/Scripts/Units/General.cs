using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

enum GeneralState
{
    START,
    SEEK,
    POWER,   
    DEATH
}

public class General : Unit
{
    [SerializeField] GeneralState myState;
    [SerializeField] TreeD<GeneralState> myTree;

    [SerializeField] LayerMask friendMask;
    [SerializeField] Collider2D[] friends;


    #region UNITYFUNCS
    private void Start()
    {
        health = maxHealth;

    }

    private void Update()
    {
        
    }
    #endregion


    #region TREEOPS
    void ChoseLowestCostNode()
    {
        Node<GeneralState> nodoDes;

        List<int> costList = new List<int>();

        foreach (Node<GeneralState> n in myTree.root.children)
        {
            costList.Add(n.cost);
        }


        int minCost = costList.Min();
        int index = costList.IndexOf(minCost);
        nodoDes = myTree.root.children[index];


        myState = myTree.BFS(nodoDes.data).data;

    }

    void ChangeNodeCost(GeneralState state, int value)
    {
        Node<GeneralState> node = myTree.BFS(state);
        node.cost = value;
    }

    #endregion


    #region UNIBEHAVIOUR

    void ChooseAction()
    {
        switch (myState)
        {
            case GeneralState.START:
                myState = GeneralState.SEEK;
                break;
            case GeneralState.SEEK:
                break;
            case GeneralState.POWER:
                break;
            case GeneralState.DEATH:
                break;
            default:
                break;
        }
    }

    void Perception()
    {
        friends = Physics2D.OverlapCircleAll(transform.position,4.0f,friendMask);
    }

    void DoSeek()
    {
        if (Vector2.Distance(transform.position, steering.target.position) > 0.2f)
        {
            steering.doSeek();
        }
        else
        {
            ChangeNodeCost(GeneralState.START, 10);
            ChangeNodeCost(GeneralState.POWER, 0);
            ChangeNodeCost(GeneralState.DEATH, 10);

        }
        ChoseLowestCostNode();
    }
    void DoPower()
    {
        if(friends.Length > 0)
        {

        }
    }
    void DoAttack()
    {
        
    }
    void DoDeath()
    {

    }
    #endregion
}
