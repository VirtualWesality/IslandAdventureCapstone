using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eat : MonoBehaviour
{
    public GameObject AudioManager;

    /// <summary>
    /// Written by: Tim Allen
    /// Credit To: Holistic3d A Simple GUI Inventory, Object Pickup and Respawn in Unity 5
    /// 
    /// How does it work?
    /// This just says hey if I click on the thing and the thing exists inside of the panel 
    /// then subtract the thing minus 1 aka eat it. If it is 0 then destroy the object from 
    /// the inventory. This is done do not touch. 
    /// </summary>


        //Add different eatme() funcstions for the different Items. logs may not be able to be consumed
        //Certain objects can play a certain sound when consumed

    public void eatme()
    {
        if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) > 1)
        {
            int tcount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
            this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	
}
