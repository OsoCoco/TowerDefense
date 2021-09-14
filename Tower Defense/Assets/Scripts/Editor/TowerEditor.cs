using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IAManager))]
public class TowerEditor : Editor
{
    /*
    private void OnSceneGUI()
    {
        IAManager manager = (IAManager)target;

        
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(manager.gameObject.transform.position, manager.transform.forward, manager.);
    }
    */
}
