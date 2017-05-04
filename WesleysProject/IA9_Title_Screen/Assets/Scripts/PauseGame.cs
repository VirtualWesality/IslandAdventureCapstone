using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public Transform Player;
    public GameObject pauseMenu;
    public GameObject pauseBackground;

    //TODO: IMPLEMENT OPTIONS MENU AND GET A WORKING EXIT BUTTON!!!SS


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
        Player.GetComponent<ThirdPersonUserControl>().enabled = false;           
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
        Player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }
}
