using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetector : MonoBehaviour
{
    public string targetTag;
    public Tower myTower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(targetTag))
        {
            myTower.enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(targetTag))
        {
            myTower.enemies.Remove(collision.gameObject);
        }
    }
}
