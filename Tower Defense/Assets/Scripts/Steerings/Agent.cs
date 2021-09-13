using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    SEEKING,
    ATTACKING,
    WANDERING,
}
public class Agent : AgentBase
{
    //public AgentBase agent;

    //[Header("Steering Var",order =1)]
    public Agent(Vector2 vel, Vector2 desVel, Transform targetAg, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m):base(vel,desVel,targetAg,s,maxVel,maxForce,maxSpeed,m){}
    public SteeringBehaviors behaviors;

    public int priority;

    [HideInInspector]
    public bool isPlayer;

    private void Start()
    {
        behaviors = new SteeringBehaviors(this);
        //actualAgents = 0;
    }

    private void Update()
    {
    }

    void UpdateTarget(Transform newTarget)
    {
       target = newTarget;
    }

    
}
