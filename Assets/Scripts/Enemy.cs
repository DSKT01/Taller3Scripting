using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Person {
    public bool alerta;
    [SerializeField]
    Renderer alertSing;
    public float _speed;
    [SerializeField]
    NavMeshAgent mNMA;
	// Use this for initialization
	void Start () {
        alertSing.enabled = false;
    
	}
    private void Update()
    {
        if (alertSing != null)
        {
            if (alerta)
                alertSing.enabled = true;
            else
                alertSing.enabled = false;
        }
        
    }
    private void FixedUpdate()
    {
        Speed = _speed;
        mNMA.speed = Speed;
    }
    protected override void Action()
    {
       
    }
}
