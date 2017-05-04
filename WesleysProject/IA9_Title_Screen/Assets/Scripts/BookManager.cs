using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour {

    public GameObject book;
    public Button bookExit;
    public Collider bookCol;

	// Use this for initialization
	void Start ()
    {
        book.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ExitPress();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //TODO: make a UI button pop up that tells the player what button to press to open book
        //So instead of open on Trigger, trigger only pops up a button prompt
        //and you wont have to disable/enable any triggers.
        book.SetActive(true);
        bookCol.enabled = false;
        
    }


    //TODO: Create Exit, Next, and Previous buttons for book UI
    public void ExitPress()
    {
        book.SetActive(false);
    }


}
