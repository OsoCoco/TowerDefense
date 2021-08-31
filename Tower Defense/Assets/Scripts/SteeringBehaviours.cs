using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours
{
    AgentBase agent;

    public SteeringBehaviours(AgentBase agent)
    {
        this.agent = agent;
    }

    public Vector2 SeekBehaviour()
    {
        if (agent == null)
        {
            Debug.Log("NO HAY AGENTE");
            return Vector2.zero;
        }

        agent.desiredVelocity = (agent.targetPos.position - agent.agentPos.position).normalized * agent.maxVelocity;
        agent.s = agent.desiredVelocity - agent.velocity;
        return agent.s;
    }

    public void Seek()
    {   
        if(agent!=null)
            Steering(SeekBehaviour());
    }

    public virtual void Steering(Vector2 ivan)
    {
        if (agent == null)
        {
            Debug.Log("NO HAY AGENTE");
            return;
        }
        Vector2 steering = ivan;
        steering = Vector2.ClampMagnitude(steering, agent.maxForce);
        steering /= agent.mass;
        agent.velocity = Vector2.ClampMagnitude(agent.velocity + steering, agent.maxSpeed);
        //agent.agentPos.position += (Vector3)agent.velocity;
        agent.agentPos.Translate(agent.velocity);
    }
}
