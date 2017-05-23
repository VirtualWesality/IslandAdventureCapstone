using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas optionsMenu;
    public Button startText;
    public Button exitText;
    public Button optionsText;

	// Use this for initialization
	void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        optionsText = optionsText.GetComponent<Button>();
        quitMenu.enabled = false;
        optionsMenu.enabled = false;

	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        optionsText.enabled = false;
    }

    public void OptionsPress()
    {
        optionsMenu.enabled = true;
        optionsText.enabled = false;    
        startText.enabled = false;
        exitText.enabled = false;     
    }

    public void ConfirmPress()
    {
        optionsMenu.enabled = false;
        optionsText.enabled = true;       
        startText.enabled = true;
        exitText.enabled = true;      
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        optionsText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Island1");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }
}
