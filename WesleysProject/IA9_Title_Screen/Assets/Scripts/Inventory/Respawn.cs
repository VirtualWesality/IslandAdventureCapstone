using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    /// <summary>
    /// Written by: Tim Allen
    /// Credit To: Holistic3dA Simple GUI Inventory, Object Pickup and Respawn in Unity 5
    /// 
    /// Doesn't do much but it does set an object at its position to false in the game world
    /// which will render it invisible after a given amount of time in this case 5 seconds
    /// it will reinstansiate at the position it was before. Need to think of a way to randomize
    /// this. 
    /// </summary>

    public GameObject cork;
    public int respawnTime = 5;
    public PickUp pickUpScript;
    public PlayerVitals playVit;

	void Start ()
	{
		if (this.gameObject.tag == "Leather")
		{
			pickUpScript = GameObject.Find("FPSController").GetComponent<PickUp>();
		}
        pickUpScript = GameObject.Find("FPSController").GetComponent<PickUp>();

    }

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKey(KeyCode.F))
        {           
            if (this.gameObject.tag == "Log")
            {
                this.GetComponent<BoxCollider>().enabled = false;
            }
            else {
                this.GetComponent<SphereCollider>().enabled = false;
            }
            
            if ((this.GetComponent<MeshRenderer>()))
            this.GetComponent<MeshRenderer>().enabled = false;

            if (this.gameObject.tag == "RopeCoil")
            {              
                for (int i = 0; i < 6; i++)
                {
                    this.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                }
            }
            if (this.gameObject.tag == "BlueMushroom" || this.gameObject.tag == "GreenMushroom" || this.gameObject.tag == "RedMushroom")
            {
                if (this.gameObject.transform.GetChild(0))
                {
                    for (int i = 0; i < this.gameObject.transform.childCount; i++)
                    {
                        this.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }

            if (this.gameObject.tag == "SailCloth")
            {
                this.gameObject.SetActive(false);
            }

            if (this.gameObject.tag == "Rum")
            {
                cork.GetComponent<MeshRenderer>().enabled = false;

            }
			if (this.gameObject.tag == "Leather")
			{
				this.gameObject.SetActive(false);
			}

            Invoke("Respawn_1", respawnTime);

            pickUpScript.pickedUp = true;
        }
    
    }

    void Respawn_1()
    {
        if (this.gameObject.tag == "Log")
        {
            this.GetComponent<BoxCollider>().enabled = true;
        }
        else{
            this.GetComponent<SphereCollider>().enabled = true;
        }

        if ((this.GetComponent<MeshRenderer>()))
            this.GetComponent<MeshRenderer>().enabled = true;

        if (this.gameObject.tag == "Rum")
        {
            cork.GetComponent<MeshRenderer>().enabled = true;
        }

        if (this.gameObject.tag == "SailCloth")
        {
            this.gameObject.SetActive(true);
        }

    }

}
