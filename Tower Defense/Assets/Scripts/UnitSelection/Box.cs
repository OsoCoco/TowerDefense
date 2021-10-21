using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [HideInInspector]
    public UnitSelection selection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
            if (collision.CompareTag("Unit"))
            {
                Debug.Log(collision.name);
                selection.unitsSelected.Add(collision.gameObject);
            }
        
    }
}
