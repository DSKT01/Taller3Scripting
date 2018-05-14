using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Person : MonoBehaviour, IAlertable {

    private float speed;

    public float Speed{get{return speed;} protected set { speed = value;} }

    

    // Use this for initialization
    void Awake () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.timeScale != 0)
            Action(); 
	}

    public virtual void Alerta()
    {

    }
    protected abstract void Action();
  
}
