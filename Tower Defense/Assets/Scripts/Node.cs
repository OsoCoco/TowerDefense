using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Node <T>
{
    [SerializeField]
    public List<Node<T>> children;
    
    [SerializeField]
     public T data;

    [SerializeField]
    public int cost;
    public Node(T s)
    {
        data = s;
        children = new List<Node<T>>();
        cost = 0;
    }

    public void AddChild(T childSate,int prio)
    {
        Node<T> node = new Node<T>(childSate);
        node.cost = prio+1;
        children.Add(node);
        
    }

    public T GetData()
    {
        return data;
    }

    public List<Node<T>> getChildren ()
    {
        return children;
    }

}
