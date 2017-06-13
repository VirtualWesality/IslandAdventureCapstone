using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int currentHealth = 100;
	private float deathCounter = 2.0f; //counter for death animation
	public GameObject Leather;
	public GameObject player;
	public Animator anim;
	private bool lootSpawned = false;
	public bool isDead = false;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			this.GetComponent<Navigation>().enabled = false;
			isDead = true;
			Death();
		}
	}

	void Death()
	{
		
		anim.Play("Big_Cat_Die");
		if(lootSpawned == false)
		{
			Instantiate(Leather, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			lootSpawned = true;
			Destroy(this.GetComponent<BoxCollider>());
			Destroy(gameObject, 2.0f);

		}

	}

}
