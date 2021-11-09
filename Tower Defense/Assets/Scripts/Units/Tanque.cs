using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum TanqueState
{
    START,
    SEEK,
    ATTACK,
    FLEE
}


public class Tanque : Unit
{

    [SerializeField] Tower myTower;
    [SerializeField] float attackRate = 0.5f;
    float nextAttack;
    

    public LayerMask enemieMask;
    public LayerMask powerUpMask;

    public TreeD<TanqueState> myTree;

    Transform actualTarget;
    
    [SerializeField]
    TanqueState myState;

    public Collider2D[] enemies;
    public Collider2D[] powerUps;


    Unit unitToAttack;

    // Start is called before the first frame update
    //myState = MeleeState.SEEK;


    #region UNITYFUNC
    private void Start()
    {
        health = maxHealth;
        actualTarget = steering.target;
        steering.position = this.transform;
        myState = TanqueState.START;

    }
    private void Update()
    {
        Perception();
        ChooseAction();
        //ChooseAction();
        //FlipX(this.GetComponent<SpriteRenderer>());
    }
    #endregion

    #region UNITBEHAVIOUR
    void ChooseAction()
    {
        switch (myState)
        {
            case TanqueState.START:
                myState = TanqueState.SEEK;
                break;
            case TanqueState.SEEK:

                DoSeek();
                break;
            case TanqueState.ATTACK:
                DoAttack();
                break;
            case TanqueState.FLEE:
                DoFlee();
                break;
            default:
                break;
        }
    }


    void ChoseLowestCostNode()
    {
        Node<TanqueState> nodoDes;

        List<int> costList = new List<int>();

        foreach (Node<TanqueState> n in myTree.root.children)
        {
            costList.Add(n.cost);
        }


        int minCost = costList.Min();
        int index = costList.IndexOf(minCost);
        nodoDes = myTree.root.children[index];


        myState = myTree.BFS(nodoDes.data).data;

       
        
    }

    void ChangeNodeCost(TanqueState state, int value)
    {
        Node<TanqueState> node = myTree.BFS(state);
        node.cost = value;
    }

    void CheckEnemies()
    {
        if (enemies.Length > 0)
        {
            //Debug.Log("enemies");

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<Unit>().steering.target == this.transform)
                {
                    this.steering.target = enemies[i].transform;
                    break;
                }
                else
                {
                    steering.target = actualTarget;
                }
            }

        }
        else
            steering.target = actualTarget;
    }
    void Perception()
    {

        enemies = Physics2D.OverlapCircleAll(transform.position, 1.5f, enemieMask);
        powerUps = Physics2D.OverlapCircleAll(transform.position, 1.5f, powerUpMask);

        CheckEnemies();

    }

    void DoAttack()
    {
        if(enemies.Length > 0)
        {
            unitToAttack = steering.target.GetComponent<Unit>();

            if(unitToAttack != null || unitToAttack.health > 0)
            {
                if(Time.time > nextAttack)
                {
                    unitToAttack.health -= 5.0f;
                    nextAttack = Time.time + attackRate;
                }
            }
            else
            {
                ChangeNodeCost(TanqueState.ATTACK, 10);
                ChangeNodeCost(TanqueState.START, 10);
                ChangeNodeCost(TanqueState.SEEK, 0);
                ChangeNodeCost(TanqueState.FLEE, 10);
            }
        }
        else
        {
            ChangeNodeCost(TanqueState.ATTACK, 10);
            ChangeNodeCost(TanqueState.START, 10);
            ChangeNodeCost(TanqueState.SEEK, 0);
            ChangeNodeCost(TanqueState.FLEE, 10);
        }

        if(enemies.Length > 1)
        {
            ChangeNodeCost(TanqueState.ATTACK, 10);
            ChangeNodeCost(TanqueState.START, 10);
            ChangeNodeCost(TanqueState.SEEK, 10);
            ChangeNodeCost(TanqueState.FLEE, 0);
        }

        ChoseLowestCostNode();
    }
    void DoFlee()
    {
        if(Vector2.Distance(transform.position,steering.target.position) < 5f)
        {
            steering.doFlee();
        }
        else
        {
            ChangeNodeCost(TanqueState.ATTACK, 10);
            ChangeNodeCost(TanqueState.START, 10);
            ChangeNodeCost(TanqueState.SEEK, 0);
            ChangeNodeCost(TanqueState.FLEE, 10);
        }

        ChoseLowestCostNode();
    }
    void DoSeek()
    {
        if(enemies.Length > 0)
        {
            steering.target = enemies[enemies.Length - 1].transform;
        }
        else
        {
            steering.target = actualTarget;
        }


        if(enemies.Length > 1)
        {
            ChangeNodeCost(TanqueState.ATTACK, 10);
            ChangeNodeCost(TanqueState.START, 10);
            ChangeNodeCost(TanqueState.SEEK, 10);
            ChangeNodeCost(TanqueState.FLEE, 0);
        }

        if(Vector2.Distance(transform.position,steering.target.position) > 1f)
        {
            steering.doSeek();
        }
        else
        {
            ChangeNodeCost(TanqueState.ATTACK, 0);
            ChangeNodeCost(TanqueState.START, 10);
            ChangeNodeCost(TanqueState.SEEK, 10);
            ChangeNodeCost(TanqueState.FLEE, 10);
        }

        ChoseLowestCostNode();
    }
    #endregion

   

}
