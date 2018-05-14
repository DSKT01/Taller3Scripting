using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    static public bool _canWin;

    [SerializeField]
    Light[] luces;
    [SerializeField]
    Transform door;
 
 
    int x;
    // Use this for initialization
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (x == 0)
        {
            if (Singleton.canWin)
            {
                for (int i = 0; i < luces.Length; i++)
                {
                    luces[i].color = Color.green;
                }
               
                x++;
            }
        }
        if (Singleton.canWin)
        {
            if (door.localScale.y > 0.1f)
            {
                door.localScale -= new Vector3(0, Time.deltaTime * 2 , 0);
                door.position -= new Vector3(0, Time.deltaTime *4 , 0);
            }          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Singleton.canWin)
        {
            if (other.GetComponent<Player>() != null)
            {
                _canWin = true;
            }
        }
        
    }
}
