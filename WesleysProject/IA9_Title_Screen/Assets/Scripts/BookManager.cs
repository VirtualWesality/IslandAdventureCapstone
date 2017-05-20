using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookManager : MonoBehaviour {


    public GameObject book;
    public Button bookExit;
    public Collider bookCol;
    public Collider raftCol;

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
        if (this.GetComponent<Collider>() == bookCol)
        {
            book.SetActive(true);
        }

        if (this.GetComponent<Collider>() == raftCol)
        {
            //Dietrich->
            //TODO:  Reference Book.cs, then -if (!bookpages[].contains bookpage_Raft) bookPages[]++ >> bookPages[totalPageCount] = sprite: bookpage_Raft
            //Unsure how to reference the Book.cs script.  From there, it should be a simple matter to increment the number of pages, and change the last page to be bookpage_Raft.
            //After that, make a collider for various objects we want to add to the journal, copy/paste, but instead of raftCol, use CatCol or whatever.  Could also
            //create a bool for each page such as ContainsRaft() which will check if it contains the raft page.  Wouldn't be too difficult, but you'd only need to call that during a specific collision
            //so it isn't really necessary.
            //<- Dietrich
        }
               
    }

    
    void OnTriggerExit(Collider other)
    {
        book.SetActive(false);
    }
    

    //TODO: Create Exit, Next, and Previous buttons for book UI
    public void ExitPress()
    {
        book.SetActive(false);
    }


}
