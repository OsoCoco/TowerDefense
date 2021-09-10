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

    public Agent(Vector2 vel, Vector2 desVel, AgentBase targetAg, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m):base(vel,desVel,targetAg,s,maxVel,maxForce,maxSpeed,m){}
    public SteeringBehaviors behaviors;

    public int priority;
    public int costo;
    public float life;

    [HideInInspector]
    public bool isPlayer;

    private void Start()
    {
        behaviors = new SteeringBehaviors(this);
        //actualAgents = 0;
    }

    private void Update()
    {
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    
}
