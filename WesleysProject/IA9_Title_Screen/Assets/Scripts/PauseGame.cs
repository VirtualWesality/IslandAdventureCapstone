using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public Transform Player;
	
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
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            Player.GetComponent<ThirdPersonUserControl>().enabled = false;
        }     
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinuePress()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }
}
