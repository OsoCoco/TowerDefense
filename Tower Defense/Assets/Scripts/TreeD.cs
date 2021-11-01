using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TreeD<T>
{
    [SerializeField]
    public Node<T> root;

    public TreeD (T data)
    {    
        root = new Node<T>(data);
    }

    public Node<T> BFS(T data)
    {
        Queue<Node<T>> myQueue = new Queue<Node<T>>();
        myQueue.Enqueue(root);
        while (myQueue.Count != 0)
        {
            Node<T> temp = myQueue.Dequeue();
            T dataTemp = temp.GetData();
            if (Compare<T>(dataTemp, data))
            {
                return temp;
            }
            else
            {
                foreach (Node<T> childTemp in temp.getChildren())
                {
                    myQueue.Enqueue(childTemp);
                }
            }
        }
        throw new Exception("No existe el Parent");
    }

    public Node<T> DFS(T data)
    {
        Stack<Node<T>> myStack = new Stack<Node<T>>();
        myStack.Push(root);
        while (myStack.Count != 0)
        {
            Node<T> temp = myStack.Pop();
            T dataTemp = temp.GetData();
            if (Compare<T>(dataTemp, data))
            {
                return temp;
            }
            else
            {
                foreach (Node<T> childTemp in temp.getChildren())
                {
                    myStack.Push(childTemp);
                }
            }
        }
        throw new Exception("No existe el Parent");
    }

    public bool Compare<TT>(TT x, TT y)
    {
        return EqualityComparer<TT>.Default.Equals(x, y);
    }
}
