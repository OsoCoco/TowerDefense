using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherTrees : MonoBehaviour
{
    public TreeD<string> myTree;

    //public Stack<bool> toVisit;

    private void Start()
    {
        myTree = new TreeD<string>("Papa");
        
        for(int i = 0; i < 5;i++)
        {
            myTree.root.AddChild("Hijo " + i,myTree.root.cost);
            myTree.root.children[i].AddChild("Nieto " + i, myTree.root.children[i].cost);
        }

        myTree.root.children[2].AddChild("Nieto Perdido", 2);


        Debug.Log(myTree.BFS("Nieto Perdido").data);
    }


}
