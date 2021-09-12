using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPerception : MonoBehaviour
{
    //EN ESTE SCRIPT SOLO DETECTAMOS LAS UNIDADES ENEMIGAS A LAS QUE ATACAREMOS
    private void OnTriggerStay2D(Collider2D collision)
    {
        //CHECAR CUANDO NUESTRO TARGET ENTRE A NUESTRO RANGO Y MANDAR A LLAMAR EL ATAQUE
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //DEJAR DE ATACAR SI EL TARGET SALE DEL RANGO
    }

}
