using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackScript : MonoBehaviour {
    public Animator anim;
    
	// Use this for initialization
	void Start ()
    {
       anim = GetComponent<Animator>();//Get Animation component, store in anim
    }
	
	// Update is called once per frame

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F)) //If player presses F
        {
            anim.SetBool("SwordSwing", true);
            
            anim.SetBool("SwordSwing", false);
            //Attack();//Call Attack
        }
		
	}

    private void Attack() //Called on click
    {        
       //  anim.Play(anim.clip.name);//Play the attack animation

    }
}
