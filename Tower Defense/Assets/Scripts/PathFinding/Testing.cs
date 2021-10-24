using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    PathFinding pf;

    [SerializeField]
    List<PathNode> path;
    private void Start()
    {
         pf = new PathFinding(5, 5);
        path = new List<PathNode>();
        //grid = new Grid(4, 4, 1f,new Vector3(0,0));
    }

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");


            Vector3 mousePos = GetMouseWorldPosition();
            pf.GetGrid().GetXY(mousePos,out int x,out int y);
            
            path = pf.FindPath(0, 0, x, y);

            if(path != null)
            {
                for (int i = 0; i < path.Count-1; i++)
                {

                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green);
                }
                
            }
        }
        
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v.z = 0;

        return v;
    }
}
