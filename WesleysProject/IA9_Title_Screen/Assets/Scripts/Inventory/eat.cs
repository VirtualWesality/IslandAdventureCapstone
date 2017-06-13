using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eat : MonoBehaviour
{
    public GameObject AudioManager;
    public PlayerVitals VitalScript;
    public float gMushTimer = 10.0f;
    private bool gMushBuff = false;

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

    private void Start()
    {
        VitalScript = GameObject.Find("FPSController").GetComponent<PlayerVitals>();
    }

    

    public void eatme()
    {
        if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) > 1) // If the thing you clicked has more than 1 item
        {
            if (gameObject.tag == "Rum" || gameObject.tag == "Coconut" || gameObject.tag == "RedMushroom" || gameObject.tag == "GreenMushroom" || gameObject.tag == "BlueMushroom")
            {
                Eat();
                if (gameObject.tag == "GreenMushroom")
                gMushBuff = true;
            }
        }
        else if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) == 1) //If you only have one left 
        {
            if (gameObject.tag == "Rum" || gameObject.tag == "Coconut" || gameObject.tag == "RedMushroom" || gameObject.tag == "BlueMushroom")
            {
                Eat();
                Destroy(this.gameObject);
            }
            else if (gameObject.tag == "GreenMushroom")
            {
                gMushBuff = true;
                Eat();
                
            }
            
        }
    }
    private void Update()
    {
        if (gMushBuff)
        {
            VitalScript.thirstFallRate = 500;
            gMushTimer -= Time.deltaTime;
            if (gMushTimer <= 0)
            {
                gMushTimer = 120;
                VitalScript.thirstFallRate = 2;
                gMushBuff = false;
                if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) == 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    //Call Eat when you press 1-6 on relevant item

    public void Eat() //If it's edible, eat it, increase or decrease stats accordingly
    {
        if (gameObject.tag == "Rum")
        {
            //INCREASE THIRST VALUE
            VitalScript.thirstSlider.value += 25;
        }
        else if (gameObject.tag == "Coconut")
        {
            //INCREASE FOOD VALUE (25?)
            VitalScript.hungerSlider.value += 25;
        }
        else if (gameObject.tag == "RedMushroom")
        {
            //INCREASE HEALTH + FOOD VALUE (20?)
            VitalScript.hungerSlider.value += 20;
            VitalScript.healthSlider.value += 20;
        }
        else if (gameObject.tag == "GreenMushroom")
        {
            //PAUSE THIRST DRAIN FOR 2(?) MINUTES           
        }
        else if (gameObject.tag == "BlueMushroom")
        {
            //DECREASE PLAYER HEALTH BY 95
            VitalScript.healthSlider.value -= 95;
        }
        //Decrement the amount of that item in your inventory
        int tcount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
        this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
    }

    public IEnumerator GreenMushroomWait()
    {
        VitalScript.thirstFallRate = 500;
        
        yield return new WaitForSeconds(2); //Change to 120 after done testing
        Debug.Log("Booyah");
        VitalScript.thirstFallRate = 0.1f;
    }

    
	
}
