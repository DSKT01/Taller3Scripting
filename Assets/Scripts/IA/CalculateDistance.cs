using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : Node {
    [SerializeField]
    float maxDistance;
    float distance;
    Vector3 deltaPos;
    Enemy _self;

    private void Start()
    {
        _self = GetComponent<Enemy>();
        deltaPos = transform.position;
    }
    public override bool Action()
    {
        distance += Vector3.Distance(transform.position, deltaPos);
        if (distance >= maxDistance)
        {
            _self.alerta = false;
            distance = 0;
        }

        deltaPos = transform.position;
        return _self.alerta;
    }
}
