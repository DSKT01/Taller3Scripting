using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy {
    [SerializeField]
    Light luz;

    [SerializeField]
    Collider _collider;
    // Use this for initialization
    void Start () {
		
	}
    private void Update()
    {
        if (alerta)
        {
            luz.color = Color.red;
            _collider.enabled = true;
        }
        else
        {
            _collider.enabled = false;
            luz.color = Color.white;
        }
    }

}
