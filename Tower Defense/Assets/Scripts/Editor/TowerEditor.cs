using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tower))]
public class TowerEditor : Editor
{
    private void OnSceneGUI()
    {
        Tower tower = (Tower)target;

        
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(tower.gameObject.transform.position, tower.transform.forward, tower.attackRange);
    }
}
