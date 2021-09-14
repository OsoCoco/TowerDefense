using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit 
{
    [Header("Unit Variables", order = 0)]
        public int HP;
        public int cost;

    [Header("Attack Variables", order = 1)]
        public int damage;
        public float attackRate;
        public float attackRange; 
    
    [Header("Steering",order = 3)]
        public AgentBase agent;
    
    //[Header("Target Reference", order = 4)]
    //  public Transform target;
      
    
    
    /* 
    [Header("Colliders", order = 2)]
        public CircleCollider2D perception;
        public CircleCollider2D range;
    */

}
