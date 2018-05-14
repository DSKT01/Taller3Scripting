using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionable : MonoBehaviour
{
    public bool myTurn;
    public bool active;
    [SerializeField]
    Light mLuz;
    private void Update()
    {
        if (!active)
            if (myTurn)
                mLuz.color = Color.blue;
            else
                mLuz.color = Color.red;
        else
            mLuz.color = Color.green;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            if (myTurn)
            {
                if (!active)
                {
                    active = true;
                    Singleton.ActiveNext();
                }
            }
        }
    }
}