using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class Raft : MonoBehaviour {

    public GameObject leaveIslandText;
    public Transform Player;
    public bool inRaftRange = false;
    public GameObject finishedRaft;
    public Transform playerSpawn;
    public MovingRaft movingRaftScript;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
	}

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && inRaftRange == true)
        {
            leaveIslandText.SetActive(true);
            Time.timeScale = 0;
            Player.GetComponent<ThirdPersonUserControl>().enabled = false;
            Player.gameObject.SetActive(false);
            GetComponent<MeshRenderer>().enabled = false;

            //Show Raft
            finishedRaft.SetActive(true);
            /*
            for (int i = 0; i < 5; i++)
            {
                finishedRaft.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
            }    
            */
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Player.gameObject.GetComponent<PickUp>().logCount >= 0)
        {
            inRaftRange = true;          
        }
    }

    public void OnYesPress()
    {
        //Player.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Island1")
        {
            //Player.transform.position = playerSpawn.transform.position;
            finishedRaft.GetComponent<MovingRaft>().enabled = true;
        }
        
        movingRaftScript.Ethan.SetActive(true);

        
        Time.timeScale = 1;
        
    }

    public void OnNoPress()
    {
        leaveIslandText.SetActive(false);
        Time.timeScale = 1;
        Player.GetComponent<ThirdPersonUserControl>().enabled = true;
        Player.gameObject.SetActive(true);
        finishedRaft.SetActive(false);
        GetComponent<MeshRenderer>().enabled = true;
    }

}
