using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Written by: Tim Allen
/// Credit To: Holistic3dA Simple GUI Inventory, Object Pickup and Respawn in Unity 5
/// 
/// How does it work?
/// 
/// This will on collision check the ID of the object that we are colliding with if it is
/// present in our inventory then the first block of code does nothing. If it is not then 
/// it will check which game object we collided with and enter that into our inventory.
/// 
/// The second block of code is to identify specific objects and will be improved upon most
/// likely with an array. Maybe pointers. Need to ask. 
/// 
/// How to add an object.
/// In order to add an object we will just create an sprite object for our inventory make it a
/// prefab and give it a tag. This tag will have to be the same as the tag for the object that 
/// is in the world. We then make sure that the object has a chosen spot in the inventory and
/// add it as a prefab after which we delete and test
/// if this does not work please see https://www.youtube.com/watch?v=CHUOprBocoY&t=1718s
/// for more information on how this was originally implemented otherwise talk to Tim Allen
/// </summary>

public class PickUp : MonoBehaviour {


    public GameObject InventoryPanel;
    public GameObject[] InventoryIcon;


    private void OnCollisionEnter(Collision collision)
    {
        //look through children for existing icon
        foreach(Transform child in InventoryPanel.transform)
        {
            //if item already in inventory
            if (child.gameObject.tag == collision.gameObject.tag)
            {
                string c = child.Find("Text").GetComponent<Text>().text;
                int tcount = System.Int32.Parse(c) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + tcount;
                return;
            }
        }
        //contains definitions for the items here will work on a better way to do this 
        //later
        GameObject i;

        if (collision.gameObject.tag == "RedFruit")
        {
            i = Instantiate(InventoryIcon[0]);
            i.transform.SetParent(InventoryPanel.transform);
        }

        if (collision.gameObject.tag == "GreenFruit")
        {
            i = Instantiate(InventoryIcon[1]);
            i.transform.SetParent(InventoryPanel.transform);
        }

        if (collision.gameObject.tag == "BlueFruit")
        {
            i = Instantiate(InventoryIcon[2]);
            i.transform.SetParent(InventoryPanel.transform);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
