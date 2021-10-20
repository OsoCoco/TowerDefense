using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestState
{
    START,
    SEEK,
    FLEE,
    MINE
}

public class TestSeek : MonoBehaviour
{
    public TestState myState;

    private Stack<int> seekCost, fleeCost, mineCost;
    public int actualSeek, actualFlee, actualMine;

    public int hp = 10;

    private void Start()
    {
        //steering.position = transform.transform;
        seekCost = new Stack<int>();
        fleeCost = new Stack<int>();
        mineCost = new Stack<int>();
    }

    private void Update()
    {
        
    }
    private void DoState()
    {
        switch(myState)
        {
            case TestState.START:
                //DO SEEK;
                break;

            case TestState.SEEK:
                //DO SEEK
                
                break;

            case TestState.FLEE:
                //DO FLEE;
                break;

            case TestState.MINE:
                //DO MINE
                break;
        }
    }

    private void DFS()
    {
        PoPStack(seekCost, actualSeek);
        PoPStack(fleeCost, actualFlee);
        PoPStack(mineCost, actualMine);

        

    }

    private void PoPStack(Stack<int> stack, int parameter)
    {
        for (int i = 0; i <= stack.Count; i++)
        {
            parameter += stack.Pop();
        }
    }
}
