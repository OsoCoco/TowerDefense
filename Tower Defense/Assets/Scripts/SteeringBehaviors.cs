using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviors
{
    AgentBase agent;

    
    public SteeringBehaviors(AgentBase agent)
    {
        this.agent = agent;
    }

 
    #region Behaviours
    Vector2 SeekBehavior(AgentBase target)
    {
        if (agent == null)
        {
            Debug.Log("NO HAY AGENTE");
            return Vector2.zero;
        }

        agent.desiredVelocity = (target.agentPos.position - agent.agentPos.position).normalized * agent.maxVelocity;
        Vector2 s;
        s = agent.desiredVelocity - agent.velocity;
        return s;
    }
    Vector2 SeekBehavior(Vector2 target)
    {
        if (agent == null)
        {
            Debug.Log("NO HAY AGENTE");
            return Vector2.zero;
        }

        agent.desiredVelocity = (target - (Vector2)agent.agentPos.position).normalized * agent.maxVelocity;
        Vector2 s;
        s = agent.desiredVelocity - agent.velocity;
        return s;
    }

    Vector2 FleeBehavior(AgentBase target)
    {
        if (agent == null)
        {
            Debug.Log("NO HAY AGENTE");
            return Vector2.zero;
        }

        agent.desiredVelocity = (agent.agentPos.position - target.agentPos.position ).normalized * agent.maxVelocity;
        agent.s = agent.desiredVelocity - agent.velocity;
        return agent.s;
    }
    Vector2 FleeBehavior(Vector2 target)
    {
        if (agent == null)
        {
            Debug.Log("NO HAY AGENTE");
            return Vector2.zero;
        }

        agent.desiredVelocity = ((Vector2)agent.agentPos.position - target).normalized * agent.maxVelocity;
        agent.s = agent.desiredVelocity - agent.velocity;
        return agent.s;
    }

    Vector2 ArrivalBehavior(float distance, float slowingRadius)
    {
        
        Vector2 sVector;
        agent.desiredVelocity = agent.target.agentPos.position - agent.agentPos.position;
        distance = agent.desiredVelocity.magnitude;

        if (distance < slowingRadius)
            agent.desiredVelocity = agent.desiredVelocity.normalized * agent.maxVelocity * (distance / slowingRadius);
        else
            agent.desiredVelocity = agent.desiredVelocity.normalized * agent.maxVelocity;

        sVector = agent.desiredVelocity - agent.velocity;

        return sVector;
    }

    Vector2 WanderBehavior(float circleDistance,float circleRadius)
    {
        Vector2 s;
        Vector2 wheel = new Vector2(agent.velocity.x,agent.velocity.y);
        //circleCenter = agent.circleCenter;

        wheel = wheel.normalized * circleDistance;

        wheel += (Vector2)agent.agentPos.position;

        Vector2 randDir = new Vector2(Random.Range(-1.0f,1.1f),Random.Range(-1.0f,1.1f));

        Debug.Log(randDir);

        randDir *= circleRadius;
        randDir += wheel;

        agent.desiredVelocity = (randDir - (Vector2)agent.agentPos.position).normalized * agent.maxVelocity;
        s = agent.desiredVelocity - (agent.velocity * 4.0f);

        return s;
    }

    Vector2 PursuitBehavior(AgentBase target)
    {
        var distance = target.agentPos.position - agent.agentPos.position;
        var T = distance.magnitude/agent.maxVelocity;

        var futurePosition = (Vector2)target.agentPos.position + target.velocity * T;

        return SeekBehavior(futurePosition);
       
    }

    Vector2 EvadeBehavior(AgentBase target)
    {
        var distance = target.agentPos.position - agent.agentPos.position;
        var T = distance.magnitude / agent.maxVelocity;

        var futurePosition = (Vector2)target.agentPos.position + target.velocity * T;
        return FleeBehavior(futurePosition);
       
    }


    Vector2 CollisionAvoidanceBehavior(AgentBase agent)
    {
        float dLength = agent.velocity.magnitude / agent.maxVelocity;
        Vector2 ahead = (Vector2)agent.agentPos.position + agent.velocity.normalized * dLength;//agent.maxSeeAhead;
        Vector2 ahead2 = ahead / 0.5f;

        Vector2 avoidance = Vector2.zero;

        Obstacle mostThreat = FindMostThreat(ahead,ahead2);
        
        if(mostThreat != null)
        {
            avoidance.x = ahead.x - mostThreat.center.x;
            avoidance.y = ahead.y - mostThreat.center.y;
            avoidance.Normalize();
            avoidance *= agent.maxAvoidForce;

        }
        else
        {
            avoidance *= 0;
        }

        return avoidance;
       
        

        //COLLISION AVOIDANCE
        //VECTOR ahead - POSITION mas NORMALIZAR(velocity) * MAX_SEE_AHEAD
        //VECTOR ahead2 - ahead entre 0.5
        //VECTOR avoidance - NUEVO VECTOR 0,0,0

        //var mostThreatening - LLAMA FindMostThreateningObstacle

        //IF mostThreatening es diferente a NULO
        //avoidance.x = ahead.x menos mostThreatening.center.x
        //avoidance.y = ahead.y menos mostThreatening.center.y

        //NORMALIZAR(avoidance)
        //ESACALAR avoidance por MAX_AVOID_FORCE
        //ELSE
        //ESCALAR avoidance por 0
        //REGRESA avoidance

    }

     Obstacle FindMostThreat(Vector2 ahead,Vector2 ahead2)
    {
        Obstacle mostThreat = null;

        Obstacle[] arrayObstacles = GameObject.FindObjectsOfType<Obstacle>();

        for (int i = 0; i < arrayObstacles.Length; i++)
        {
            Obstacle obs = arrayObstacles[i];
            bool col = LineIntersectsCircle(ahead,ahead2,obs);
            if (col && (mostThreat == null || Vector2.Distance(agent.agentPos.position, obs.center) < Vector2.Distance(agent.agentPos.position, mostThreat.center)))
            {
                mostThreat = obs;
            }
        }
        return mostThreat;
        //FUNCIONES
        //OBSTACLE FUNCTION FindMostThreateningObstacle
        //VAR mostThreatening es NULA
        //FOR para ver cuántos objetos son Obstáculos
        //VAR obstacle - obstacles[i]
        //VAR collison - LLAMADA a LineIntersectsCircle
        //IF collison Y (mostThreatening es NULO || la DISTANCIA entre la POSICION y obstacle es MENOR a la DISTANCIA entre POSICION y mostThreatening )
        //mostThreatening  - obstacle

        //REGRESA mostThreatening.

    }

    bool LineIntersectsCircle(Vector2 ahead,Vector2 ahead2, Obstacle obs)
    {
        return Vector2.Distance(obs.center,ahead) <= obs.radius || Vector2.Distance(obs.center,ahead2) <= obs.radius;
        //BOOL FUNCTION LineIntersectsCircle RECIBE ahead, ahead2, obstacle
        //CHECA la DISTANCIA entre el CENTRO del obstaculo y ahead O ahead2, si alguno es menor o igual al RADIO OBASTACULO entonces REGRESA verdadero.
    }

    #endregion

    #region BehavioursCalls
    public void Flee()
    {
        if (agent != null)
            Steering(FleeBehavior(agent.target));
    }
    public void Seek()
    {   
        if(agent!=null)
            Steering(SeekBehavior(agent.target));
    }

    public void Arrival()
    {
        if (agent != null)
            Steering(ArrivalBehavior(agent.distance,agent.slowingRadius));
    }

    public void Wander()
    {
        if (agent != null)
            Steering(WanderBehavior(agent.circleDistance,agent.circleRadius));

    }
    public void Pursuit()
    {
        if (agent != null)
            Steering(PursuitBehavior( agent.target));

    }
    public void Evade()
    {
        if (agent != null)
            Steering(EvadeBehavior(agent.target));

    }
    #endregion

    void Steering(Vector2 sVector)
    {
        if (agent == null )
        {
            Debug.Log("NO HAY AGENTE");
            return;
        }

        Vector2 steering = Vector2.zero;
        steering += sVector;
        steering += CollisionAvoidanceBehavior(agent);
        steering = Vector2.ClampMagnitude(steering, agent.maxForce);
        steering /= agent.mass;
        agent.velocity = Vector2.ClampMagnitude(agent.velocity + steering, agent.maxSpeed);
        //agent.agentPos.position += (Vector3)agent.velocity;
        agent.agentPos.Translate(agent.velocity * Time.deltaTime);
    }

    

    

    /*
    public void ArrivalSteering(Vector2 sVector)
    {
        if (agent == null)
        {
            Debug.Log("NO HAY AGENTE");
            return;
        }
        Vector2 steering = sVector;
        agent.velocity = Vector2.ClampMagnitude(agent.velocity + steering, agent.maxSpeed);
        //agent.agentPos.position += (Vector3)agent.velocity;
        agent.agentPos.Translate(agent.velocity * Time.deltaTime);
    }
    */

}
