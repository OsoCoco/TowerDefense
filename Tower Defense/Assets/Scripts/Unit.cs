using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    BARBARO,
    ARQUERA,
    KAMIKAZE,
    PIPILA,
    CANON,
    BOMBARDERO,
    LADRON,
    MINERO,
    GENERAL,
}

[System.Serializable]
public class Unit:MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] int cost;
    [SerializeField] int attackDamage;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackRange;

    [SerializeField] List<Unit> priority;
    [SerializeField] Transform target;

    public Type myType;
    public float spawnTime;
    public bool isPlayer = false;

     void Attack()
    {
      Debug.Log("Attacking");
    }

    void Steal()
    {
        Debug.Log("Robando");
    }
    
     void Death()
    {
        Debug.Log("Death");
    }

    void GoTo()
    {

    }

    void ChooseAction()
    {
        //Switch case

    }
}
