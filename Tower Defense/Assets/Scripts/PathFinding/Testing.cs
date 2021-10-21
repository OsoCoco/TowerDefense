using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    Grid grid;
    private void Start()
    {
        grid = new Grid(4, 4, 1f,new Vector3(0,0));
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(),56);
        }

         if(Input.GetMouseButtonDown(1))
        {
            Debug.Log( grid.GetValue(GetMouseWorldPosition()));
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v.z = 0;

        return v;
    }
}
