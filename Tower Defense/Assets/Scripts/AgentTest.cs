using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentTest: AgentBase
{
    public SteeringBehaviors myBehaviour;

    public bool player;
  
    public AgentTest(Vector2 vel, Vector2 desVel, AgentBase target, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m) : base(vel, desVel, target, s, maxVel, maxForce, maxSpeed, m)
    {
       
    }

    private void Start()
    {
        myBehaviour = new SteeringBehaviors(this);
        
    }

    private void Update()
    {

        //myBehaviour.Flee();


        myBehaviour.Seek();
        //myBehaviour.Arrival();
        
        /*
        if (player)
            myBehaviour.Pursuit();
        else
            myBehaviour.Evade();
        */

        //myBehaviour.Wander();
    }
}
