using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Person
{

    float realSpeed, initialSpeed;
    [SerializeField]
    Transform puntero;
    public SphereCollider[] colliders;
    float[] initialSizes;
    [SerializeField]
    CursorMovement tpIndicator;
    public static bool reloadingEnergy;
    bool slowingTime;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Speed = 5;
        realSpeed = Speed;
        initialSpeed = Speed;
        initialSizes = new float[colliders.Length];
        for (int i = 0; i < colliders.Length; i++)
        {
            initialSizes[i] = colliders[i].radius;
        }
    }

    void Movement()
    {
        Speed = realSpeed;
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].radius = initialSizes[i];
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = realSpeed * 1.5f;
            
                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].radius *= 1.5f;
                }
            
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Speed = realSpeed / 2;
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].radius /= 1.5f;
            }
        }



        transform.Rotate(0, (Input.GetAxis("Mouse X")) * Time.deltaTime * 1000, 0);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * Speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * Speed), Space.Self);
    }
    void SkillManager()
    {
        if (Singleton.Energy <= 1)
        {
            reloadingEnergy = true;
        }
        if (Singleton.Energy >= 99)
        {
            reloadingEnergy = false;
        }
        if (!reloadingEnergy)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                StartCoroutine(tpIndicator.Funcion(true));
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                transform.position = puntero.position;
                Singleton.Energy -= 20;
                StartCoroutine(tpIndicator.Funcion(false));
            }

            if (Input.GetKey(KeyCode.Mouse1))
                slowingTime = true;
            else
                slowingTime = false;

            if (slowingTime)
            {
                Time.timeScale = 0.5f;
                realSpeed = initialSpeed * 5;
                Singleton.Energy -= Time.deltaTime * 50;
            }
            else
            {
                Time.timeScale = 1;
                realSpeed = initialSpeed;
            }

        }
        else
        {
            Time.timeScale = 1;
            realSpeed = initialSpeed;
            StartCoroutine(tpIndicator.Funcion(false));
            slowingTime = false;
        }

    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            SkillManager();
        }
    }
    
    protected override void Action()
    {
        Movement();


    }
    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.GetComponent<Enemy>() != null && !(_collision.gameObject.GetComponent<Collider>().isTrigger))
        {
            Singleton.ActiveEndGameCanvas();
        }
    }

}
