using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Node {

    [SerializeField]
    protected Node[] sons;

    public override bool Action()
    {
        for (int i = 0; i < sons.Length; i++)
        {
            sons[i].Action();
        }
        return true;
    }
}
