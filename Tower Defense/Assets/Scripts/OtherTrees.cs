using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherTrees : MonoBehaviour
{
    public TreeD<bool> myTree;

    public Stack<bool> toVisit;

    private void Start()
    {
        myTree.root.addChild(false);
        myTree.root.addChild(false);
        myTree.root.children[0].state = true;
    }


}
