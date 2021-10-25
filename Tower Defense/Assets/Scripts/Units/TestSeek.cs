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

public class TestSeek : Unit
{
    public TestState actualState;
    public LayerMask mask;

    public TreeD<TestState> myTree;

    Transform actualTarget;
    //private Stack<int> seekCost, fleeCost, mineCost;
    //public int actualSeek, actualFlee, actualMine;

    //public int hp = 10;

    public Collider2D[] enemies;
    private void Start()
    {
        //myTree = new TreeD<TestState>(TestState.START);
        //steering.position = transform.transform;
        //seekCost = new Stack<int>();
        //fleeCost = new Stack<int>();
        //mineCost = new Stack<int>();
        //StartCoroutine(DFS());


         actualTarget = steering.target;
        //ChoseLowestCostNode();
    }

    private void Update()
    {
        //ChooseState();
        Perception();
    }
    private void DoState()
    {
        /* 
        switch(myState)
        {
            case TestState.START:
                myState = TestState.SEEK;
                break;

            case TestState.SEEK:
                if (actualSeek > actualMine && actualMine < actualFlee)
                {
                    myState = TestState.MINE;
                }
                else if(actualSeek < actualFlee && actualMine > actualFlee)
                {
                    myState = TestState.FLEE;
                }
                
                break;

            case TestState.FLEE:
                if (actualFlee > actualSeek && actualSeek < actualMine)
                {
                    myState = TestState.MINE;
                }
                else if (actualFlee > actualMine && actualMine < actualSeek)
                {
                    myState = TestState.FLEE;
                }

                break;

            case TestState.MINE:
                if (actualMine > actualSeek && actualSeek < actualFlee)
                {
                    myState = TestState.FLEE;
                }
                else if (actualMine > actualSeek && actualSeek < actualFlee)
                {
                    myState = TestState.SEEK;
                }
                break;
        }*/


       
    }

    /*
    private IEnumerator DFS()
    {
        yield return new WaitForEndOfFrame();
        PoPStack(seekCost, actualSeek);
        PoPStack(fleeCost, actualFlee);
        PoPStack(mineCost, actualMine);

        DoState();

        StartCoroutine(DFS());

    }*/

    void ChooseState()
    {
        switch (actualState)
        {
            case TestState.START:
                actualState = TestState.SEEK; //COSTO DE SEEK SEA MENOR
                break;
            case TestState.SEEK: //COSTO DE SEEK SEA MENOR
                steering.doSeek();
                //actualState = TestState.MINE;
                break;
            case TestState.FLEE://COSTO DE FLEE SEA MENOR
                steering.doFlee();
                actualState = TestState.SEEK;
                break;
            case TestState.MINE://COSTO DE MINE SEA MENOR
                Mine();
                actualState = TestState.SEEK;
                break;
            default:
                break;
        }
    }

    void Mine()
    {
        Debug.Log("Minando");
        
        if(enemies.Length > 0)
        {
            Debug.Log("Enemigos");
            //steering.target = enemies[0].transform;
            actualState = TestState.FLEE;
        }
        //MINAR NORMAL
        //SI TENGO ENEMIGOS VEO SI ES MAS DE UNO SI NO ATACO, SI ES MAS CORRO


        //CHOSELOWESTCOSTNODE
        
        
    }

    //SEEK 
    //FLEE
    //ATTACK

    void ChangeNodeCost(Node<TestState> node,int value)
    {
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

        enemies = Physics2D.OverlapCircleAll(transform.position,3.0f,mask);
        //Transform actualTarget;
        switch (actualState)
        {
            case TestState.START:
                actualState = TestState.SEEK; //COSTO DE SEEK SEA MENOR
                break;
            case TestState.SEEK: //COSTO DE SEEK SEA MENOR

                if (enemies.Length == 0)
                {
                    steering.target = actualTarget;
                    //actualState = TestState.SEEK;
                    if (Vector2.Distance(steering.position.position, steering.target.position) > 1f)
                        steering.doSeek();
                    else
                        actualState = TestState.MINE;
                }
                else
                {
                    steering.target = enemies[0].transform;
                    actualState = TestState.FLEE;
                }

                //actualState = TestState.MINE;
                break;
            case TestState.FLEE://COSTO DE FLEE SEA MENOR
                
                if(enemies.Length > 0)
                {
                    steering.target = enemies[0].transform;

                    if (Vector2.Distance(steering.position.position, steering.target.position) < 2f)
                        steering.doFlee();
                    
                }
                else
                {
                    steering.target = actualTarget;
                    actualState = TestState.SEEK;
                }
                //actualState = TestState.SEEK;
                break;
            case TestState.MINE://COSTO DE MINE SEA MENOR
                Mine();
                break;
            default:
                break;
        }
    }

    

    private void PoPStack(Stack<int> stack, int parameter)
    {
        for (int i = 0; i <= stack.Count; i++)
        {
            parameter += stack.Pop();
        }
    }
}
