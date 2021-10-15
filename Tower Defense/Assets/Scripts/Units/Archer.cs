using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    
    ArcherState myState = ArcherState.START;

    [SerializeField]
    TreeD<ArcherState> tree;
    //myState = ArcherState.SEEK;

    private void Start()
    {
        steering.position = this.transform;
        myState = ArcherState.SEEK;
    }
    private void Update()
    {
        ChooseAction();
        //FlipX(this.GetComponent<SpriteRenderer>());
    }

    void ChooseAction()
    {
        switch (myState)
        {
            case ArcherState.START:
                break;
            case ArcherState.SEEK:
                //steering.doWander();
                Debug.Log("Evade");
                break;
            case ArcherState.SHOOT:
                break;
            case ArcherState.FLEE:
                break;
            default:
                break;
        }
    }
}

enum ArcherState
{
    START,
    SEEK,
    SHOOT,
    FLEE,
}
