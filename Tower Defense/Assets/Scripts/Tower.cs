using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int life;
    public float attackRange, attackDamage;
    public LayerMask mask;

    public GameObject go;

    private void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position,attackRange,mask);

       
    }

    void TargetSelection(Agent agent)
    {

    }
}
