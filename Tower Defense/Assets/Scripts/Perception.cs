using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Perception : MonoBehaviour
{
    //EN ESTE SCRIPT DETECTAMOS LAS UNIDADES Y LAS CLASIFICAMOS COMO TARGETS (AQUI SOLO VEMOS LAS UNIDADES PERO NO LAS ATACAMOS)
    private void OnTriggerStay2D(Collider2D collision)
    {
        //CHECAR LAS UNIDADES QUE ENTRAN SI SON ENEMIGOS AGREGARLOS A UNA LISTA Y CAMBIAR EL TARGET DEPENDIENDO DE LA PRIORIDAD
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //LIMAR DE LA LISTA LAS UNIDADES QUE SALGAN DEL RANGO
    }

}
