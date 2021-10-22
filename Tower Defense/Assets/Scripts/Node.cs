using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Node <T>
{
    [SerializeField]
    public List<Node<T>> children;
    
    [SerializeField]
     public T state;

    [SerializeField]
    public int priority;
    public Node(T s)
    {
        state = s;
        children = new List<Node<T>>();
        priority = 0;
    }

    public void addChild(T childSate)
    {
        children.Add(new Node <T>(childSate));
    }

    public List<Node<T>> getChildren ()
    {
        return children;
    }

}
