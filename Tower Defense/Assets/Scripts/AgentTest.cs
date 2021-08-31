using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentTest: AgentBase
{
    public SteeringBehaviours myBehaviour;

    public AgentTest(Vector2 vel, Vector2 desVel, Vector2 targetPos, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m) : base(vel, desVel, targetPos, s, maxVel, maxForce, maxSpeed, m)
    {

    }

    private void Start()
    {
        myBehaviour = new SteeringBehaviours(this);
    }

    private void Update()
    {
        myBehaviour.Seek();
    }
}
