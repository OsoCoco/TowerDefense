using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 center;
    public float radius = 1;
    // Start is called before the first frame update

    private void Awake()
    {
        center = transform.position;
    }

}
