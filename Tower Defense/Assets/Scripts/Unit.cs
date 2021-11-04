using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Unit:MonoBehaviour
{
    public SteeringManager steering;

    
    public float health;
    
    [SerializeField]
    protected float maxHealth;
   

   
    public void FlipX(SpriteRenderer sp)
    {
        if (steering.position.position.x > steering.target.position.x)
            sp.flipX = true;
        else
            sp.flipX = false;
    }

    
}

[System.Serializable]
public class SteeringManager
{

    Vector2 velocity;
    Vector2 desiredVelocity;
    Vector2 steering;

    public Transform position;
    public Transform target;

    float wanderAngle;

    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float maxForce;
    [SerializeField]
    float maxVelocity;
    [SerializeField]
    float mass;
    [SerializeField]
    float slowingRadius;
    [SerializeField]
    float attackRadius;
    [SerializeField]
    float circleDistance;
    [SerializeField]
    float circleRadius;
    [SerializeField]
    float angleChange;


    public void doSeek() 
    {
        Steering(Seek());
    }
    public void doFlee() 
    {
        Steering(Flee());
    }
    public void doWander() 
    {
        Steering(Wander());
    }
    
    public void doPursuit() 
    {
        Steering(Pursuit());    
    }

    public void doEvade()
    {
        Steering(Evade());
    }

    public void doInterpose(Unit a, Unit b)
    {
        Steering(Interpose(a,b));
    }

    Vector2 Seek()
    {
      
        desiredVelocity = (Vector2)(target.position - position.position) * maxVelocity;
        Vector2 s = desiredVelocity - velocity;
        return s;
    }

    Vector2 Seek(Vector2 targetPos)
    {
        desiredVelocity = (targetPos - (Vector2)position.position) * maxVelocity;
        Vector2 s = desiredVelocity - velocity;
        return s;
    }

    Vector2 Flee()
    {
      
        desiredVelocity = (Vector2)(position.position - target.position) * maxVelocity;
        Vector2 s = desiredVelocity - velocity;
        return s;
    }

    Vector2 Flee(Vector2 targetPos)
    {
        desiredVelocity = ((Vector2)position.position - targetPos) * maxVelocity;
        Vector2 s = desiredVelocity - velocity;
        return s;
    }

    Vector2 Arrival()
    {

        desiredVelocity = (Vector2)(target.position - position.position);

        float distance = desiredVelocity.magnitude;//- attackRadius;

        if (distance < slowingRadius)
            desiredVelocity = desiredVelocity.normalized * maxVelocity * (distance / slowingRadius);
        else
            desiredVelocity = desiredVelocity.normalized * maxVelocity;
        Vector2 s = desiredVelocity - velocity;
        return s;
    }

    Vector2 Arrival(Vector2 pos)
    {

        desiredVelocity = (pos - (Vector2)position.position);

        float distance = desiredVelocity.magnitude;//- attackRadius;

        if (distance < slowingRadius)
            desiredVelocity = desiredVelocity.normalized * maxVelocity * (distance / slowingRadius);
        else
            desiredVelocity = desiredVelocity.normalized * maxVelocity;
        Vector2 s = desiredVelocity - velocity;
        return s;
    }

    Vector2 Wander()
    {
        Vector2 circleCenter = new Vector2();
        circleCenter = velocity;
        circleCenter.Normalize();
        circleCenter *= circleDistance;

        Vector2 displacement = new Vector2();
        displacement = new Vector2(0, -1);
        displacement *= circleRadius;

        displacement = SetAngle(displacement,wanderAngle);

        wanderAngle += Random.Range(0f,1f) * angleChange - angleChange  * 0.5f ;

        Vector2 wanderForce = new Vector2();
        wanderForce = circleCenter + displacement;

        return wanderForce;

    }
    
    Vector2 Pursuit()
    {
        Vector2 distance = (Vector2)(target.position - position.position);

        int t =(int)( distance.magnitude / maxVelocity);

        Vector2 futurePos = ((Vector2)target.position + target.GetComponent<Unit>().steering.velocity)* t;

        return Seek(futurePos);
    }

    Vector2 Evade()
    {
        Vector2 distance = (Vector2)(target.position - position.position);

        int t = (int)(distance.magnitude / maxVelocity);

        Vector2 futurePos = ((Vector2)target.position + target.GetComponent<Unit>().steering.velocity) * t;

        return Flee(futurePos);
    }

    Vector2 Interpose(Unit a,Unit b)
    {
        Vector2 midPoint = (Vector2)(a.steering.position.position + b.steering.position.position) / 2.0f;

        float t = Vector2.Distance(position.position,midPoint)/maxSpeed;

        Vector2 aPos = ((Vector2)a.steering.position.position + a.steering.velocity)* t;
        Vector2 bPos = ((Vector2)b.steering.position.position + b.steering.velocity) * t;

        midPoint = (aPos + bPos) / 2;

        return Arrival(midPoint);

    }

   
    
    public void Steering(Vector2 force)
    {
        //steering = new Vector2(Vector2.zero);
        steering = force;
        steering = Vector2.ClampMagnitude(steering, maxForce);
        steering /= mass;

        velocity = Vector2.ClampMagnitude(velocity + steering, maxSpeed);

        position.Translate(velocity);
    }

    
    public Vector2 SetAngle(Vector2 v, float value)
    {
        Vector2 w = new Vector2();
        float mag = v.magnitude;

        w.x = Mathf.Cos(value) * mag;
        w.y =Mathf.Sin(value) *mag ;

        return w;
    }
}

