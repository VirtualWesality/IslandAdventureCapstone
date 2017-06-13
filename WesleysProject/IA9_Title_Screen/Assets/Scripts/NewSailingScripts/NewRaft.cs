using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class NewRaft : MonoBehaviour {

    public GameObject leaveIslandText;
    public Transform Player;
    public bool inRaftRange = false;
    public int logCount, sailClothCount, ropeCount, leatherCount;
    public GameObject finishedRaft;
    public GameObject finishedRaft2;
    public NewMovingRaft movingRaftScript;
    public GameObject BookManager;
    public GameObject inventoryPanel;
    public NewGameManager gmScript;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            //if (SceneManager.GetActiveScene().name == "Island1")
            if (gmScript.currentIsland == 1)
            {               
                finishedRaft.GetComponent<NewMovingRaft>().enabled = true;
            }
            else if (gmScript.currentIsland == 2)
            {
                finishedRaft2.GetComponent<NewMovingRaft>().enabled = true;
            }

            
            Player.GetComponent<PickUp>().logCount = 0;
            Player.GetComponent<PickUp>().sailClothCount = 0;

            foreach (Transform child in inventoryPanel.transform)
            {
                if (child.gameObject.tag == "SailCloth" || child.gameObject.tag == "Log" || child.gameObject.tag == "RopeCoil" || child.gameObject.tag == "Leather")
                {
                    Destroy(child.gameObject);
                }
            }

            

            if (movingRaftScript.gmScript.currentIsland > 1)
            {
                movingRaftScript.Point = gmScript.setNextIsland2SailingSpot(0);
            }
            
            Debug.Log("Continues to be lit");
            inRaftRange = false;
            Time.timeScale = 1;
        }

        if (Input.GetKey(KeyCode.N))
        {
            leaveIslandText.SetActive(false);
            Time.timeScale = 1;
            Player.gameObject.SetActive(true);
            if (gmScript.currentIsland == 1)
            {
                finishedRaft.transform.GetChild(7).gameObject.SetActive(false);
            }
            if (gmScript.currentIsland == 2)
            {
                finishedRaft2.transform.GetChild(1).gameObject.SetActive(false);
            }
            GetComponent<MeshRenderer>().enabled = true;
        }

        if (Input.GetKey(KeyCode.R) && inRaftRange == true)
        {
            leaveIslandText.SetActive(true);
            Time.timeScale = 0;          
            Player.gameObject.SetActive(false);
            GetComponent<MeshRenderer>().enabled = false;

            if (gmScript.currentIsland == 1)
            {
                finishedRaft.transform.GetChild(7).gameObject.SetActive(true);
            }

            if (gmScript.currentIsland == 2)
            {
                finishedRaft2.transform.GetChild(1).gameObject.SetActive(true);
            }

            //Show Raft
            if (gmScript.currentIsland == 1)
            {
                finishedRaft.SetActive(true);
            } else if (gmScript.currentIsland == 2)
            {
                finishedRaft2.SetActive(true);
                gmScript.numberOfSailingSpots = gmScript.sailingSpotsIsland2.Length;
            }
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
        logCount = Player.gameObject.GetComponent<PickUp>().logCount;
        sailClothCount = Player.gameObject.GetComponent<PickUp>().sailClothCount;
        ropeCount = Player.gameObject.GetComponent<PickUp>().ropeCount;
        leatherCount = Player.gameObject.GetComponent<PickUp>().leatherCount;


        if (gmScript.currentIsland == 1)
        {
            if (other.tag == "Player" && logCount >= 0)
            {
                inRaftRange = true;
            }

       /*
       //One that works. Using one above for ease of testing purposes
       if (other.tag == "Player" && logCount >= 6 && sailClothCount >= 1 && BookManager.GetComponent<BookManager>().HasJournal == true && ropeCount >=1)
       {
           inRaftRange = true;          
       }
       */
        }

        if (gmScript.currentIsland == 2)
        {
            if (other.tag == "Player" && logCount >= 0)
            {
                inRaftRange = true;
            }
            /*
            if (other.tag == "Player" && logCount >= 8 && ropeCount >= 2 && leatherCount >= 2 )
            {
                inRaftRange = true;
            }
            */
        }

        if (gmScript.currentIsland == 3)
        {
            if (other.tag == "Player" && logCount >= 0)
            {
                inRaftRange = true;
            }
            /*
            if (other.tag == "Player" && logCount >= 10 && ropeCount >= 3 && leatherCount >= 5)
            {
                inRaftRange = true;
            }
            */
        }




    }




}
