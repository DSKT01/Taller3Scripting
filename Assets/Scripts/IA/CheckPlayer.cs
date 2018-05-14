using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : Node
{
    Enemy _self;
    private void Start()
    {
        _self = GetComponent<Enemy>();
    }
    public override bool Action()
    {
        return _self.alerta;
    }
    private void OnTriggerEnter(Collider _collision)
    {
        if (_collision.gameObject.GetComponent<Player>() != null)
        {
            _self.alerta = true;
            _self._speed = 7;
        }
       
    }
 

}
