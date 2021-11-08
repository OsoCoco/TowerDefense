using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum CanonState
{
    START,
    SEEK,
    IDLE,
    ATTACK,
}

public class Canon : Unit
{
    [SerializeField] CanonState myState;
    [SerializeField] Tower myTower;
    [SerializeField] float attackRate = 1.0f;

    float nextAttack;
    public LayerMask enemieMask;

    public TreeD<CanonState> myTree;

    Transform actualTarget;
    Collider2D[] enemies;

    Unit unitToAttack;
    #region UNITFUNCS

    private void Start()
    {
        health = maxHealth;
        actualTarget = steering.target;
        steering.position = this.transform;
        myState = CanonState.START;
    }
    private void Update()
    {
        Perception();
        ChooseAction();
    }
    #endregion

    #region UNITBEHAVIOUR
    void ChooseAction()
    {
        switch (myState)
        {
            case CanonState.START:
                myState = CanonState.SEEK;
                break;
            case CanonState.SEEK:
                DoSeek();
                break;
            case CanonState.ATTACK:
                DoAttack();
                break;
            case CanonState.IDLE:
                DoIdle();
                break;
            default:
                break;
        }
    }

    void DoSeek()
    {
        if(Vector2.Distance(transform.position,steering.target.position) > 0.2f)
        {
            steering.doSeek();
        }
        else
        {
            ChangeNodeCost(CanonState.START, 10);
            ChangeNodeCost(CanonState.IDLE, 0);
            ChangeNodeCost(CanonState.ATTACK, 10);
            ChangeNodeCost(CanonState.SEEK, 10);
        }
        ChoseLowestCostNode();
    }
    void DoIdle()
    {
        if(enemies.Length > 0)
        {
            unitToAttack = enemies[0].GetComponent<Unit>();
            ChangeNodeCost(CanonState.START, 10);
            ChangeNodeCost(CanonState.IDLE, 10);
            ChangeNodeCost(CanonState.ATTACK, 0);
            ChangeNodeCost(CanonState.SEEK, 10);
        }
        else
        {
            unitToAttack = null;
            ChangeNodeCost(CanonState.START, 10);
            ChangeNodeCost(CanonState.IDLE, 0);
            ChangeNodeCost(CanonState.ATTACK, 10);
            ChangeNodeCost(CanonState.SEEK, 10);
        }

        ChoseLowestCostNode();
    }
    void DoAttack()
    {

        if(enemies.Length > 0)
        {
            if(unitToAttack != null )
            {
                if(Time.time > nextAttack)
                {
                    unitToAttack.health -= 2.0f;
                    nextAttack = Time.time + attackRate;
                }
            }
            else 
            {
                ChangeNodeCost(CanonState.START, 10);
                ChangeNodeCost(CanonState.IDLE, 0);
                ChangeNodeCost(CanonState.ATTACK, 10);
                ChangeNodeCost(CanonState.SEEK, 10);
            }
        }
        else
        {
            ChangeNodeCost(CanonState.START, 10);
            ChangeNodeCost(CanonState.IDLE, 0);
            ChangeNodeCost(CanonState.ATTACK, 10);
            ChangeNodeCost(CanonState.SEEK, 10);
        }

        ChoseLowestCostNode();
    }

    void Perception()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, 2.5f, enemieMask);
    }
    #endregion

    #region TREEOPS
    void ChoseLowestCostNode()
    {
        Node<CanonState> nodoDes;

        List<int> costList = new List<int>();

        foreach (Node<CanonState> n in myTree.root.children)
        {
            costList.Add(n.cost);
        }


        int minCost = costList.Min();
        int index = costList.IndexOf(minCost);
        nodoDes = myTree.root.children[index];


        myState = myTree.BFS(nodoDes.data).data;

    }

    void ChangeNodeCost(CanonState state, int value)
    {
        Node<CanonState> node = myTree.BFS(state);
        node.cost = value;
    }



    #endregion
}
