using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AgentBase
{
    //Steering Variables
    public Transform targetPos;
    //[HideInInspector]
    public Transform myPos;

    public AgentBase target;

    [HideInInspector]
    public Vector3 velocity, desiredVelocity, s;
    public float maxVelocity, maxForce, maxSpeed,maxSeeAhead,maxAvoidForce,mass, slowingRadius, circleDistance, circleRadius;

    [HideInInspector]
    public float distance;

    //[HideInInspector]
    public SteeringBehaviors behaviors;
}
