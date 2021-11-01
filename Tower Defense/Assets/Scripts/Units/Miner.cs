using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum TestState
{
    START,
    SEEK,
    FLEE,
    MINE
}

public class Miner : Unit
{

    [SerializeField] Tower myTower;
    [SerializeField] float mineRate = 1.0f;
    [SerializeField] int goldPerRate = 1;
    float nextMine;
    public TestState actualState;
    public LayerMask enemieMask;
    public LayerMask powerUpMask;

    public TreeD<TestState> myTree;

    Transform actualTarget;
   

    public Collider2D[] enemies;
    public Collider2D[] powerUps;
    private void Start()
    {

         actualTarget = steering.target;

    }

    private void Update()
    {
        ChooseState();
        Perception();
    }
    
    void ChooseState()
    {
        switch (actualState)
        {
            case TestState.START:
                actualState = TestState.SEEK; 
                break;
            case TestState.SEEK: 
                Seek();
                break;
            case TestState.FLEE:
                Flee();
                
                break;
            case TestState.MINE:
                Mine();
                
                break;
            default:
                break;
        }
    }

    void Mine()
    {
        if(myTower.gold <= myTower.maxGold)
        {
            if(Time.time > nextMine)
            {
                Debug.Log("mining");
                nextMine = Time.time + mineRate;
                myTower.gold += goldPerRate;
            }

        }

        Debug.Log("Minando");

     
        if (steering.target != actualTarget)
        {
            Debug.Log("Enemigos");

            ChangeNodeCost(TestState.MINE, 10);
            ChangeNodeCost(TestState.START, 10);
            ChangeNodeCost(TestState.SEEK, 10);
            ChangeNodeCost(TestState.FLEE, 0);
        }
        

        ChoseLowestCostNode();
        
    }


    void Seek()
    {
     
        if (steering.target  == actualTarget)
        {
            //steering.target = actualTarget;
            
            if (Vector2.Distance(steering.position.position, steering.target.position) > 1f)
            {
                steering.doSeek();
            }
            else
            {
                ChangeNodeCost(TestState.MINE, 0);
                ChangeNodeCost(TestState.START, 10);
                ChangeNodeCost(TestState.SEEK, 10);
                ChangeNodeCost(TestState.FLEE, 10);
            }
        }
        else
        {
            //steering.target = enemies[0].transform;
          
            ChangeNodeCost(TestState.MINE, 10);
            ChangeNodeCost(TestState.START, 10);
            ChangeNodeCost(TestState.SEEK, 10);
            ChangeNodeCost(TestState.FLEE, 0);
        }

        ChoseLowestCostNode();

    }

    //VER SI SOY TARGET ALGUN ENEMIGO 
    void Flee()
    {
        if (steering.target != actualTarget)
        {
            if (Vector2.Distance(steering.position.position, steering.target.position) < 2f)
            {
                steering.doFlee();
            }

        }
        else
        {
            steering.target = actualTarget;

            ChangeNodeCost(TestState.MINE, 10);
            ChangeNodeCost(TestState.START, 10);
            ChangeNodeCost(TestState.SEEK, 0);
            ChangeNodeCost(TestState.FLEE, 10);
        }


        ChoseLowestCostNode();
    }
   

    void ChangeNodeCost(TestState state,int value)
    {
        Node<TestState> node = myTree.BFS(state);
        node.cost = value;
    }

    void ChoseLowestCostNode()
    {
        Node<TestState> nodoDes;

        List<int> costList = new List<int>();

        foreach(Node<TestState> n in myTree.root.children)
        {
            costList.Add(n.cost);
        }

        
        int minCost = costList.Min();
        int index = costList.IndexOf(minCost);
        nodoDes = myTree.root.children[index];


        actualState = myTree.BFS(nodoDes.data).data;

        Debug.Log(myTree.BFS(nodoDes.data).ToString());
        Debug.Log(myTree.BFS(nodoDes.data).cost);
        //nodoActual = myTree.root.children.Min();

    }
    void Perception()
    {

        enemies = Physics2D.OverlapCircleAll(transform.position,3.0f,enemieMask);
        powerUps = Physics2D.OverlapCircleAll(transform.position, 3.0f, powerUpMask);


        CheckEnemies();
       
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
    

    private void PoPStack(Stack<int> stack, int parameter)
    {
        for (int i = 0; i <= stack.Count; i++)
        {
            parameter += stack.Pop();
        }
    }
}
