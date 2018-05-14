using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovement : Node {
    bool _return;
    int x;
    [SerializeField]
    int maxNumberOfSteps;
    Vector3 deltaPos;
    public override bool Action()
    {
        
        if (x >= maxNumberOfSteps)
        {
            _return = true;
            x = 0;
        }
        else
        {
            if (transform.position == deltaPos)
            {
                x++;
            }
            _return = false;
        }
        deltaPos = transform.position;
        return _return;
    }
}
