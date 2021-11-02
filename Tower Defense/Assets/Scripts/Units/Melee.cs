using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Melee : Unit
{

    [SerializeField] Tower myTower;
    [SerializeField] float attackRate = 1.0f;
    float nextAttack;
  
    public LayerMask enemieMask;
    public LayerMask powerUpMask;

    public TreeD<MeleeState> myTree;

    Transform actualTarget;
    
    
    MeleeState myState;
    // Start is called before the first frame update
    //myState = MeleeState.SEEK;

    private void Start()
    {
        steering.position = this.transform;
        myState = MeleeState.SEEK;

    }
    private void Update()
    {
        ChooseAction();
        //FlipX(this.GetComponent<SpriteRenderer>());
    }

    void ChooseAction()
    {
        switch (myState)
        {
            case MeleeState.START:
                break;
            case MeleeState.SEEK:
               // steering.doPursuit();
                Debug.Log("Seek");
                break;
            case MeleeState.ATTACK:
                break;
            default:
                break;
        }
    }


    void ChoseLowestCostNode()
    {
        Node<MeleeState> nodoDes;

        List<int> costList = new List<int>();

        foreach (Node<MeleeState> n in myTree.root.children)
        {
            costList.Add(n.cost);
        }


        int minCost = costList.Min();
        int index = costList.IndexOf(minCost);
        nodoDes = myTree.root.children[index];


        myState = myTree.BFS(nodoDes.data).data;

        Debug.Log(myTree.BFS(nodoDes.data).ToString());
        Debug.Log(myTree.BFS(nodoDes.data).cost);
        
    }

    void ChangeNodeCost(MeleeState state, int value)
    {
        Node<MeleeState> node = myTree.BFS(state);
        node.cost = value;
    }
}

public enum MeleeState
{
    START,
    SEEK,
    ATTACK,
}
