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
        StartCoroutine(DFS());
    }

    private void Update()
    {
        
    }
    private void DoState()
    {
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
        }
    }

    private IEnumerator DFS()
    {
        yield return new WaitForEndOfFrame();
        PoPStack(seekCost, actualSeek);
        PoPStack(fleeCost, actualFlee);
        PoPStack(mineCost, actualMine);

        DoState();

        StartCoroutine(DFS());

    }



    private void PoPStack(Stack<int> stack, int parameter)
    {
        for (int i = 0; i <= stack.Count; i++)
        {
            parameter += stack.Pop();
        }
    }
}
