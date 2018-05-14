using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {
    [SerializeField]
    GameObject canvasPause, canvasInGame;
    bool isPaused;
    public static bool isDead;
	// Use this for initialization
	void Start () {
        canvasPause.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            if (!isPaused)
                Pause();
            else
                Continue();

        if (isDead)
            if (Input.GetKeyDown(KeyCode.Escape))
                Restart();
	}

    public void Continue()
    {
        isPaused = false;
        canvasPause.SetActive(false);
        canvasInGame.SetActive(true);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        isPaused = true;
        canvasPause.SetActive(true);
        canvasInGame.SetActive(false);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
}
