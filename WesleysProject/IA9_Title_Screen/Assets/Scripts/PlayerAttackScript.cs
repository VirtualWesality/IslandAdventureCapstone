using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackScript : MonoBehaviour {

    public Animator anim;
    public Collider collider;
    private bool EnemyInRange = false;
    private float attackCooldown = 1.0f;
    private bool atkCooldown = false;
    
	// Use this for initialization
	void Start ()
    {
       anim = GetComponent<Animator>();//Get Animation component, store in anim
    }
	
	// Update is called once per frame

	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && attackCooldown == 1.0f) //If player presses F
        {
            anim.Play("SaberAnimation");     //Swing!       
            if (EnemyInRange && !atkCooldown) //If enemy in range and your attack is not on cooldown...
            {
                /*Lower enemy health here! FOR REAL, THOUGH*/
                
                atkCooldown = true; //Put attack on cooldown
                //Debug.Log("Attack!");

            }
        }
        
        if (atkCooldown) //If attack is on cooldown
        {
            attackCooldown -= Time.deltaTime;      //Decrement for 1 second      
            //Debug.Log(attackCooldown);

            if (attackCooldown < 0) //If cooldown reaches 0
            {
                attackCooldown = 1.0f; //Reset cooldown timer to 1
                atkCooldown = false; // Remove the cooldown
               // Debug.Log(attackCooldown);
            }
        }

    
	}

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyInRange = true;
            //Debug.Log("Enemy In Range.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyInRange = false;
            //Debug.Log("Enemy No Longer In Range.");
        }
    }

}
