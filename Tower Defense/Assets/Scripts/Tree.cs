using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TreeD<T>
{
    [SerializeField]
    public Node<T> root;

    public TreeD (T state)
    {    
        root = new Node<T>(state);
    }


}
