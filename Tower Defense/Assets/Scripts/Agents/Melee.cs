
using UnityEngine;
public class Melee : MonoBehaviour
{
    [SerializeField]
    Unit unit;

    private void Awake()
    {
        unit.agent.behaviors = new SteeringBehaviors(unit.agent);
        //unit.agent.myPos = transform;
    }

    //CONSIDERO QUE LOS AGENDES DEBERIAN DE HEREDAR DE AGENT BASE Y NO DE AGENT YA QUE SOLO NECESITAMOS LOS COMPORTAMIENTOS DEL STEERING PARA HACER QUE FUNCIONE ESTA WEA
    //EN ESTE SCRIPT SOLO MANEJAMOS LOS ESTADOS LA UNIDAD COMO SU FUNCION DE ATAQUE, CAMINAR, ETC.
    //TANTO COMO EL MELEE Y EL RANGE SON LA MISMA UNIDAD SOLO CAMBIAN LOS RANGOS CON QUE ESTE UNA YA ESTA LA OTRA :3
    //ATACA POR PRIORIDAD


    private void Update()
    {
        unit.agent.behaviors.Seek();
    }

}
