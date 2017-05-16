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
        SceneManager.LoadScene("IslandTwoElectricBoogaloo");
    }

    public void OnNoPress()
    {
        leaveIslandText.SetActive(false);
        Time.timeScale = 1;
        Player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }
}
