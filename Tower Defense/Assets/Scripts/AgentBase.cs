using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AgentBase: MonoBehaviour
{
    //Steering Variables
    public AgentBase target;
    [HideInInspector]
    public Transform agentPos;
    [HideInInspector]
    public Vector2 velocity, desiredVelocity, s;
    public float maxVelocity, maxForce, maxSpeed,maxSeeAhead,maxAvoidForce,mass, slowingRadius, circleDistance, circleRadius;
    [HideInInspector]
    public float distance;
    
    
    
    //

    //Constructor
    public AgentBase(Vector2 vel, Vector2 desVel, AgentBase targetAg, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m,float d = 0,
                       float sR = 0, float circleDistance= 0, float circleRadius = 0,float mSA = 0,float mAF = 0)
    {
        velocity = vel;
        desiredVelocity = desVel;
        this.target = targetAg;
        this.agentPos.position = transform.position;
        this.s = s;
        maxVelocity = maxVel;
        this.maxForce = maxForce;
        this.maxSpeed = maxSpeed;
        maxSeeAhead = mSA;
        maxAvoidForce = mAF;
        mass = m;
        distance = d;
        slowingRadius = sR;
    }

 

   

    private void Awake()
    {
        agentPos = GetComponent<Transform>();
    }
}
