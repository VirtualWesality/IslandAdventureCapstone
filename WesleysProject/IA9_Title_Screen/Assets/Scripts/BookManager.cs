using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookManager : MonoBehaviour {


    public GameObject book;
    public Button bookExit;
    public Collider bookCol;
    public Collider raftCol;
    public bool HasJournal;
    public GameObject InventoryPanel, JournalPanel;
    public GameObject FPSController;
    

	// Use this for initialization
	void Start ()
    {
        book.SetActive(false);
        HasJournal = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {           
            if (HasJournal)
            {
                if (book.activeSelf)
                {
                    
                    book.SetActive(false);
                    InventoryPanel.SetActive(true);
                    JournalPanel.SetActive(true);
                   
                }
                else
                {
                    InventoryPanel.SetActive(false);
                    JournalPanel.SetActive(false);
                    book.SetActive(true);
                }
            }
        }

        if (HasJournal)
        {
            if (book.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.LeftBracket))
                {
                    //page left
                    book.GetComponent<AutoFlip>().FlipLeftPage();
                }
                if (Input.GetKeyDown(KeyCode.RightBracket))
                {
                    //page right
                    book.GetComponent<AutoFlip>().FlipRightPage();
                }
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        //TODO: make a UI button pop up that tells the player what button to press to open book
        //So instead of open on Trigger, trigger only pops up a button prompt
        //and you wont have to disable/enable any triggers.
        if (this.GetComponent<Collider>() == bookCol)
        {
            book.SetActive(true);
            InventoryPanel.SetActive(false);
            HasJournal = true;
            Destroy(GameObject.FindGameObjectWithTag("Journal"));
        }
		               
    }

    
    void OnTriggerExit(Collider other)
    {
        JournalPanel.SetActive(true);
		InventoryPanel.SetActive(true);
        book.SetActive(false);

        Destroy(this.gameObject.GetComponent<BoxCollider>());
    }
    
    public void ExitPress()
    {
        book.SetActive(false);
    }


}
