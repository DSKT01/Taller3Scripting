using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAlerta : Node {

    
    Enemy _self;
    private void Start()
    {
        _self = GetComponent<Enemy>();
    }
    public override bool Action()
    {

        return _self.alerta;
    }
}
