using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PathNode 
{
    Grid<PathNode> grid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFrom;

    public bool isWalkable;
    public PathNode(Grid<PathNode> grid,int x,int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}
