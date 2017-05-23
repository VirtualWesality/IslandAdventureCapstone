using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public Transform Player;
    public GameObject pauseMenu;
    public GameObject pauseBackground;


    void Start()
    {
        pauseMenu.SetActive(false);
        pauseBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
	}

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseBackground.SetActive(true);
        Time.timeScale = 0;          
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinuePress()
    {
        pauseMenu.SetActive(false);
        pauseBackground.SetActive(false);
        Time.timeScale = 1;      
    }
}
