using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    //CONSIDERO QUE LOS AGENDES DEBERIAN DE HEREDAR DE AGENT BASE Y NO DE AGENT YA QUE SOLO NECESITAMOS LOS COMPORTAMIENTOS DEL STEERING PARA HACER QUE FUNCIONE ESTA WEA
    //EN ESTE SCRIPT SOLO MANEJAMOS LOS ESTADOS LA UNIDAD COMO SU FUNCION DE ATAQUE, CAMINAR, ETC.
    //ESTE MENSO ES IGUAL QUE EL RANGE SOLO QUE ESTE EN VEZ DE HACER DA�O A UNA UNIDAD EN ESPECIFICO DA�A A TODAS LAS UNIDADES DENTRO DE UN AREA
    //PARA ESTO SE ME OCURRE QUE DENTRO DE SU RANGO DE ATAQUE, SI DETECTA A UNA UNIDAD EN VEZ DE ATACARLA INSTANCIE UNA "BOMBA" QUE HAGA DA�O A LAS UNIDADES ENEMIGAS
    //ESTA BOMBA YA TENDRA SU ATQUE Y SU DA�O EN AREA, CREO QUE SERIA M�S FACIL DE PROGRAMAR YA QUE SOLO SERIA HACER DOS PREFABS DE BOMBAS UNA PARA BOMBAS QUE HACEN DA�O AL PLAYER Y OTRA QUE HACE DA�O A LA IA

    private void Attack()
    {

    }

    private void GoToTower()
    {

    }
}
