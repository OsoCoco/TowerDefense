
using UnityEngine;
public class Melee : Agent
{
    //CONSIDERO QUE LOS AGENDES DEBERIAN DE HEREDAR DE AGENT BASE Y NO DE AGENT YA QUE SOLO NECESITAMOS LOS COMPORTAMIENTOS DEL STEERING PARA HACER QUE FUNCIONE ESTA WEA
    //EN ESTE SCRIPT SOLO MANEJAMOS LOS ESTADOS LA UNIDAD COMO SU FUNCION DE ATAQUE, CAMINAR, ETC.
    //TANTO COMO EL MELEE Y EL RANGE SON LA MISMA UNIDAD SOLO CAMBIAN LOS RANGOS CON QUE ESTE UNA YA ESTA LA OTRA :3
    //ATACA POR PRIORIDAD
    public State myState;

    public Melee(Vector2 vel, Vector2 desVel, Transform targetAg, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m) : base(vel, desVel, targetAg, s, maxVel, maxForce, maxSpeed, m) { }
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

    private void Attack()
    {

    }

    private void GoToEnemyTower()
    {

    }
}
