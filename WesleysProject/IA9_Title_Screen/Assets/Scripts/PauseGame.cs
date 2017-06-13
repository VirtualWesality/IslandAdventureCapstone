using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public Transform Player;
    public GameObject pauseMenu;
    public GameObject pauseBackground;
    public FirstPersonController mouselook;


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
        mouselook.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
        mouselook.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;      
    }
}
