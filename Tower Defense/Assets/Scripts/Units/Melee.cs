using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Unit
{
    MeleeState myState;
    // Start is called before the first frame update
    //myState = MeleeState.SEEK;

    private void Start()
    {
        steering.position = this.transform;
        myState = MeleeState.SEEK;

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
            case MeleeState.START:
                break;
            case MeleeState.SEEK:
                steering.doPursuit();
                Debug.Log("Seek");
                break;
            case MeleeState.ATTACK:
                break;
            case MeleeState.WANDER:
                steering.doWander();
                break;
            case MeleeState.DIE:
                break;
            default:
                break;
        }
    }

}

public enum MeleeState
{
    START,
    WANDER,
    SEEK,
    ATTACK,
    DIE,
}
