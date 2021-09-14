using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    //ESTE SCRIPT YA NO HACE FALTA :c
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

    private void Update()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, mask);
        //target = ObjectToAttack(enemies);

        if (target != null && Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            //Attack(target);
        }
    }
   /* Agent ObjectToAttack(Collider2D[] col)
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

        if (objectToAttack != null)
        {
            if (!objectToAttack.isPlayer)
                return objectToAttack;
            else
                return null;
        }
        else
            return null;
    }
 /*   void Attack(Agent t)
    {
        if (t != null)
            t.life -= attackDamage;

    }*/

   /* public void SpawnAgent(GameObject objectToSpawn)
    {
        GameObject temp = objectToSpawn;

        Agent agenTemp = temp.GetComponent<Agent>();

        recursos -= agenTemp.costo;
        agenTemp.isPlayer = true;

        Instantiate(temp, transform.position, Quaternion.identity);
    }*/
   
}
