using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Variables", order = 0)]
    public int HP;
    public int damage;
    public float speedDamage;
    public float rangePerception;
    public float rangeAttack;

    [Header("Colliders", order = 1)]
    public CircleCollider2D perception;
    public CircleCollider2D range;

    [Header("Tower Targets", order = 1)]
    public Unit actualTarget;
    public List<Unit> targets;

    //IMPORTANTEEEEEEEEEEE AGREGAR IDENTIFICADOR SI PERTENECEN AL JUGADOR O LA IA Y CUALES SON SUS ENEMIGOS, ESTE SCRIPT SOLO SERVIRA PARA LA BASE (OSEA ATACAR UNIDADES Y PARA CAMBIAR EL ESTADO DEL JUEGO EN CASO DE QUE SU VIDA LLEGE A 0)
    //ATACA A LA UNIDAD CON MENOR VIDA

    private void attack()
    {

    }

    /*
    public GameObject[] agentsToSpawn;

    public float life;
    public float attackRange, attackDamage;
    public float attackRate;

    public int recursos;
    public float spawnRate;
    float nextAgent;
    public int agentLimit;


    [SerializeField] int actualAgents;

    float nextAttack;
    public LayerMask mask;

    public Collider2D[] enemies;
    List<int> prio;
    
    public Agent target;
    //public Agent agentToAttack;

    private void Update()
    {
       enemies = Physics2D.OverlapCircleAll(transform.position,attackRange,mask);
       target = ObjectToAttack(enemies);

        if(target != null && Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            //Attack(target);
        }

       if(recursos > 0 && actualAgents < agentLimit && Time.time > nextAgent)
       {
            nextAgent = Time.time + spawnRate;
            //SpawnAgent();
            actualAgents++;
       }
      

    }

    Agent ObjectToAttack(Collider2D[] col)
    {
        Agent objectToAttack;

        if (col != null)
        {
            prio = new List<int>();

            for (int i = 0; i < col.Length; i++)
            {
                prio.Add(col[i].GetComponent<Agent>().priority);
            }

            if (prio.Count != 0)
            {
                int maxPrio = prio.Max();

                Debug.Log("Max Prio " + maxPrio);

                int index = prio.IndexOf(maxPrio);
                Debug.Log("Index " + index);

                objectToAttack = col[index].gameObject.GetComponent<Agent>();
            }
            else
                objectToAttack = null;
        }
        else
            objectToAttack = null;

        if(objectToAttack != null)
        {
            if (objectToAttack.isPlayer)
                return objectToAttack;
            else
                return null;
        }
        else
            return null;
    }
    
    /*void Attack(Agent t)
    {
      if(t != null)  
        t.life -= attackDamage;
      
    }*/

    /*void SpawnAgent()
    {
        GameObject temp = agentsToSpawn[Random.Range(0, agentsToSpawn.Length)];

        Agent agenTemp = temp.GetComponent<Agent>();

        recursos -= agenTemp.costo;
        agenTemp.isPlayer = false;
        
        Instantiate(temp, transform.position, Quaternion.identity);
    }*/

    //return agentsToSpawn[Random.Range(0, agentsToSpawn.Length)];
}


