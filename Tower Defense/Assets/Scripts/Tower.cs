using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int life;
    public float attackRange, attackDamage;
    public LayerMask mask;

    public Collider2D[] enemies;
    List<int> prio;
    
    public Agent target;
    //public Agent agentToAttack;

    private void Update()
    {
       enemies = Physics2D.OverlapCircleAll(transform.position,attackRange,mask);
       target = ObjectToAttack(enemies);
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
       

        return objectToAttack;
    }
    
    
}
