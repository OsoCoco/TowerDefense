using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Unit 
{
    [SerializeField]
    SteeringManager steering;

    public virtual void ChooseAction()
    {
        Debug.Log("Funcion que determina que hacer");
    }

    
}

[System.Serializable]
class SteeringManager
{
    Vector2 velocity;
    Vector2 desiredVelocity;
    Vector2 steering;
    
    Transform position;
    Transform target;
    
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float maxForce;
    [SerializeField]
    float maxVelocity;
    [SerializeField]
    float mass;


    public void doSeek() 
    {
        Steering(Seek());
    }
    void doFlee() { }
    void doWander() { }

    Vector2 Seek()
    {
        velocity = (target.position - position.position) * maxVelocity;
        desiredVelocity = (target.position - position.position) * maxVelocity;
        Vector2 s = desiredVelocity - velocity;
        return s;
    }
    public void Steering(Vector2 force)
    {
        steering = Vector2.zero;
        steering = force;
        steering = Vector2.ClampMagnitude(steering, maxForce);
        steering = steering / mass;

        velocity = Vector2.ClampMagnitude(velocity + steering, maxSpeed);

        position.Translate((Vector2)position.position + velocity);
    }

}

