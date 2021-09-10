
using UnityEngine;
public class Archer : Agent
{
    public Archer(Vector2 vel, Vector2 desVel, AgentBase targetAg, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m) : base(vel, desVel, targetAg, s, maxVel, maxForce, maxSpeed, m) { }
    public State myState;

    private void Start()
    {
        myState = State.WANDERING;
        behaviors = new SteeringBehaviors(this);
    }

    private void Update()
    {
        switch (myState)
        {
            case State.SEEKING:
                break;
            case State.ATTACKING:
                break;
            case State.WANDERING:
                behaviors.Wander();
                break;
            default:
                break;
        }
    }
}