using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializator : MonoBehaviour {

    [SerializeField]
    private Node root;

    public float maxTime;

    private float t;

    private void Update()
    {
        t += Time.deltaTime;
        if (t >= maxTime)
        {
            root.Action();
            t = 0f;
        }
    }
}
