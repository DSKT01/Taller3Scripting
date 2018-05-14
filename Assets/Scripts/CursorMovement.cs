using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CursorMovement : MonoBehaviour
{

    [SerializeField]
    Transform offSet, sprite;
    [SerializeField]
    Renderer mRend;
    NavMeshAgent _agent;
    // Use this for initialization
    void Awake()
    {
        mRend.enabled = false;
    }

    public IEnumerator Funcion(bool _in)
    {
        yield return new WaitForFixedUpdate();
        if (_in)
        {
            mRend.enabled = false;
            transform.position = offSet.position;
            
          

            mRend.enabled = true;
        }
        else
        {
            mRend.enabled = false;
            
        }
    }
}
