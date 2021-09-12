using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Agent
{
    //CONSIDERO QUE LOS AGENDES DEBERIAN DE HEREDAR DE AGENT BASE Y NO DE AGENT YA QUE SOLO NECESITAMOS LOS COMPORTAMIENTOS DEL STEERING PARA HACER QUE FUNCIONE ESTA WEA
    //EN ESTE SCRIPT SOLO MANEJAMOS LOS ESTADOS LA UNIDAD COMO SU FUNCION DE ATAQUE, CAMINAR, ETC.
    //ESTE MENSO SOLO VA LA TORRE ENEMIGA EN VERGIZA SI LO MATAN O SI LLEGA A SU OBJETIVO ESTA UNIDAD MUERE E INFLIGUE DAÑO A TODAS LAS UNIDADES QUE ESTEN DENTRO DE SU RANGO DE ATAQUE
    public State myState;

    public Kamikaze(Vector2 vel, Vector2 desVel, Transform targetAg, Vector2 s, float maxVel, float maxForce, float maxSpeed, float m) : base(vel, desVel, targetAg, s, maxVel, maxForce, maxSpeed, m) { }
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

    private void GoToEnemyTower()
    {

    }

    private void KBoom()
    {

    }
}
