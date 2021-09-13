using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Unit Variables", order = 0)]
    public int HP;
    //public float speed; LO AGREGAMOS EN EL STEERING?
    public float rangePerception; //EN QUE RANGO OBTIENEN SU TARGET;
    public int cost;

    [Header("Attack Variables", order = 1)]
    public int damage;
    public float speedAttack;
    public float rangeAttack; //EN QUE RANGO EMPIEZAN ATACAR A SU TARGET;

    [Header("Colliders", order = 2)]
    public CircleCollider2D perception;
    public CircleCollider2D range;

    //IMPORTANTEEEEEEEEEEE AGREGAR EL TARGET PERMANENTE DE LA BASE ENEMIGA (PLAYER O IA), AGREGAR IDENTIFICADOR SI PERTENECEN AL JUGADOR O LA IA Y CUALES SON SUS ENEMIGOS, ESTE SCRIPT SOLO MANEARA ESTADOS DE LA UNIDAD (SI AUN ESTA VIVO O MUERTO Y COSAS ASI)

    private void Start()
    {
        SetRanges();
    }

    //AGREGAMOS EL VALOR DEL RANGO DE PERCEPCION Y DE ATAQUE A NUESTROS COLLIDERS
    private void SetRanges()
    {
        perception.radius = rangePerception;
        range.radius = rangeAttack;
    }

    //LE REDUCIMOS LA VIDA A LA UNIDAD Y CHECAMOS SI AUN TIENE VIDA
    public int SetDamage(int value)
    {
        HP -= value;
        if (HP <= 0)
        {
            Die();
        }
        return HP;
    }

    //MANDAMOS A DESTRUIR EL OBJETO
    private void Die()
    {
        Destroy(gameObject);
    }


}
