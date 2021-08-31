using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AgentBase: MonoBehaviour
{
    //Steering Variables
    public Vector2 velocity, desiredVelocity, s;
    public Transform targetPos;
    [HideInInspector]
    public Transform agentPos;
    public float maxVelocity, maxForce, maxSpeed, mass;
    //

    //Constructor
    public AgentBase(Vector2 vel, Vector2 desVel, Vector2 targetPos, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m)
    {
        velocity = vel;
        desiredVelocity = desVel;
        this.targetPos.position = targetPos;
        this.agentPos.position = transform.position;
        this.s = s;
        maxVelocity = maxVel;
        this.maxForce = maxForce;
        this.maxSpeed = maxSpeed;
        mass = m;
    }

    private void Awake()
    {
        agentPos = GetComponent<Transform>();
    }
}
