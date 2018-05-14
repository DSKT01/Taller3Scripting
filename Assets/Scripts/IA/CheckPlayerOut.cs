using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerOut : Node {

    Enemy _self;
    
    private void Start()
    {
      
        _self = GetComponent<Enemy>();
    }
    public override bool Action()
    {
        
            

        return _self.alerta;
    }
    private void OnTriggerExit(Collider _collision)
    {
        if (_collision.GetComponent<Player>() != null)
        {
            _self.alerta = false;
        }
    }
}
