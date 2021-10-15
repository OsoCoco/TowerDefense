using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] Unit u;
    ArcherState myState = ArcherState.START;

    [SerializeField]
    TreeD<ArcherState> tree;
    private void Start()
    {
        tree = new TreeD<ArcherState>(myState);
    }
}

enum ArcherState
{
    START,
    SEEK,
    SHOOT,
    FLEE,
}
