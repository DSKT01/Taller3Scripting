using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour
{
    private static float energy;

    public static float Energy { get { return energy; } set { energy = Mathf.Clamp(value, 0, 100); } }

    static Singleton _instance;

    [SerializeField]
    GameObject _panelWin;
    static GameObject panelWin;
    [SerializeField]
    Win win;
    [SerializeField]
    Text textWin;
    static Actionable[] actionables;
    static Actionable selected;
    public static Stack<Actionable> orden;
    public static bool canWin = false;
    // Use this for initialization
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Energy = 150;
        panelWin = _panelWin;
        panelWin.SetActive(false);
        actionables = FindObjectsOfType<Actionable>();
        orden = new Stack<Actionable>();
        orden.Push(null);
        for (int i = 0; i < actionables.Length; i++)
        {
            orden.Push(actionables[i]);
        }


    }
    private void Start()
    {
        ActiveNext();
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.reloadingEnergy)
        {
            Energy += Time.deltaTime * 3;
        }
        Energy += Time.deltaTime;

        //temp
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
        {
            Energy++;
        }    

    }
    private void FixedUpdate()
    {
        if (Time.time != 0)
        {
        if (Win._canWin)
        {
                textWin.text = "Victory";
                ActiveEndGameCanvas();
        }
        }
    }
    public static void ActiveEndGameCanvas()
    {
        CanvasController.isDead = true;
        Time.timeScale = 0;
        panelWin.SetActive(true);
    }

    public static void ActiveNext()
    {

        if (orden.Peek() != null)
            selected = orden.Peek();
        else
            canWin = true;

        for (int i = 0; i < actionables.Length; i++)
        {
            if (actionables[i] == selected)
            {
                actionables[i].myTurn = true;
             
            }
            else
            {
                actionables[i].myTurn = false;
            }
        }
   
        orden.Pop();
    }
    
}
