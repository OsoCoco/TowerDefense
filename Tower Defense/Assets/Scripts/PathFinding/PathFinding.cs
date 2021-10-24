using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathFinding 
{
    const int MOVE_STRAIGHT_COST = 10;
    const int MOVE_DIAGONAL_COST = 14;

    Grid<PathNode> grid;

    [SerializeField]
    List<PathNode> openList;
    
    [SerializeField]
    List<PathNode> closedList;
    public PathFinding(int w,int h)
    {
        grid = new Grid<PathNode>(w,h,2,Vector3.zero,(Grid<PathNode> g,int x,int y) => new PathNode(g,x,y));
    }

    public List<PathNode> FindPath(int startX,int starY,int endX,int endY)
    {
        PathNode startNode = grid.GetValue(startX, starY);
        PathNode endNode = grid.GetValue(endX, endY);

        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();


        for(int x= 0;x < grid.GetWidth();x++)
        {
            for(int y =0;y < grid.GetHeight();y++)
            {
                PathNode node = grid.GetValue(x, y);
                node.gCost = int.MaxValue;
                node.CalculateFCost();
                node.cameFrom = null;
            }
        }

        
        startNode.gCost = 0;
        startNode.hCost = CalculateDistance(startNode, endNode);
        startNode.CalculateFCost();

        while(openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);

            if(currentNode == endNode)
            {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach(PathNode n in GetNeighbourList(currentNode))
            {
                if (closedList.Contains(n)) continue;
                if (!n.isWalkable) { closedList.Add(n); continue; }

                int tentativeGCost = currentNode.gCost + CalculateDistance(currentNode, n);

                if(tentativeGCost < n.gCost)
                {
                    n.cameFrom = currentNode;
                    n.gCost = tentativeGCost;
                    n.hCost = CalculateDistance(n, endNode);
                    n.CalculateFCost();

                    if(!openList.Contains(n))
                    {
                        openList.Add(n);
                    }
                }
            }
        }

        //Out of nodes on the openList

        return null;

    }


    public Grid<PathNode> GetGrid()
    {
        return grid;
    }

    int CalculateDistance(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);

        int remaining = Mathf.Abs(xDistance - yDistance);

        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    List<PathNode> GetNeighbourList(PathNode currentNode)
    {
        List<PathNode> nList = new List<PathNode>();

        if(currentNode.x - 1 >= 0)
        {
            //Left
            nList.Add(GetNode(currentNode.x - 1, currentNode.y));
            //LeftDown
            if (currentNode.y - 1 >= 0) nList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
            //LeftUp
            if (currentNode.y + 1 < grid.GetHeight()) nList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        if (currentNode.x+1<grid.GetWidth())
        {
            //Right
            nList.Add(GetNode(currentNode.x + 1, currentNode.y));
            //RightDown
            if (currentNode.y - 1 >= 0) nList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
            //RightUp
            if (currentNode.y + 1 < grid.GetHeight()) nList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        //Down
        if (currentNode.y - 1 >= 0) nList.Add(GetNode(currentNode.x, currentNode.y - 1));
        //Up
        if (currentNode.y + 1 < grid.GetHeight()) nList.Add(GetNode(currentNode.x, currentNode.y + 1));

        return nList;
    }

    PathNode GetNode(int x,int y)
    {
        return grid.GetValue(x, y);
    }
    List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();

        path.Add(endNode);

        PathNode currentNode = endNode;

        while(currentNode.cameFrom != null)
        {
            path.Add(currentNode.cameFrom);
            currentNode = currentNode.cameFrom;
        }

        path.Reverse();
        return path;

    }

    PathNode GetLowestFCostNode(List<PathNode> pahtNodeList)
    {
        PathNode lowestFCostNode = pahtNodeList[0];

        for(int i =1;i < pahtNodeList.Count;i++)
        {
            if(pahtNodeList[i].fCost <lowestFCostNode.fCost)
            {
                lowestFCostNode = pahtNodeList[i];
            }
        }
        return lowestFCostNode;

    }
}
