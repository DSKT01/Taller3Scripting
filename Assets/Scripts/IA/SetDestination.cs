using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetDestination : Node {
    [SerializeField]
    Transform target;
    [SerializeField]
    float areaSize;
    NavMeshAgent _self;
    Vector3 initialPos;
    Enemy self;
    private void Start()
    {
        _self = GetComponent<NavMeshAgent>();
        initialPos = transform.position;
        self = GetComponent<Enemy>();
    }
    public override bool Action()
    {
        if (target != null)
        {
            _self.SetDestination(target.position);
        }
        else
        {
            _self.SetDestination(new Vector3(Random.Range(initialPos.x - (int)(areaSize / 2f), initialPos.x + (int)(areaSize / 2f)) + 1, transform.position.y, Random.Range(initialPos.z - (int)(areaSize / 2f), initialPos.z + (int)(areaSize / 2f) + 1)));
            self._speed = 4;
        }
        return true;
    }
}
