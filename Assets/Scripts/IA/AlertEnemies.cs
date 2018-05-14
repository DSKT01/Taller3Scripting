using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertEnemies : Node {

    Enemy _self;
    
   
    private void Start()
    {
        _self = GetComponent<Enemy>();
    }
    public override bool Action()
    {      
        return true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (_self.alerta)
        {
            if (other.GetComponent<Enemy>() != null && other.GetComponent<Enemy3>() == null)
            {
                other.GetComponent<Enemy>().alerta = true;
            }
        }
    }
}
