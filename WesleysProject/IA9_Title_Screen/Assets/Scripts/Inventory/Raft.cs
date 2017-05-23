using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class Raft : MonoBehaviour {

    public GameObject leaveIslandText;
    public Transform Player;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            leaveIslandText.SetActive(true);
            Time.timeScale = 0;
            Player.GetComponent<ThirdPersonUserControl>().enabled = false;
        }
    }

    public void OnYesPress()
    {
        if (SceneManager.GetActiveScene().name == "Island1")
        { SceneManager.LoadScene("IslandTwoElectricBoogaloo"); }
        else if (SceneManager.GetActiveScene().name == "IslandTwoElectricBoogaloo")
        { SceneManager.LoadScene("island3"); }
        else if (SceneManager.GetActiveScene().name == "island3")
        { SceneManager.LoadScene("Title"); }
        Time.timeScale = 1;
        
    }

    public void OnNoPress()
    {
        leaveIslandText.SetActive(false);
        Time.timeScale = 1;
        Player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }
}
