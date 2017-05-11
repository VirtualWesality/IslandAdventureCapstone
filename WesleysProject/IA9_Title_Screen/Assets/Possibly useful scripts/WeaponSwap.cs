using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponSwap : MonoBehaviour {

	public GameObject weapon01;
	public GameObject weapon02;

	public bool handGun;
	public bool semiGun;

	public Slider healthBar;
	public Text healthText;
	public int healthCount = 100;

	public Slider shieldBar;
	public Text shieldText;
	public int shieldCount = 100;

	pickUpScript reticles;

	public Text Dead;
	FirstPersonController playerScript;

	void Start()
	{
		//setting both guns to false, player has no guns.
		weapon01.SetActive (false);
		weapon02.SetActive (false);

		//two boolean values which help enable gun swapping
		handGun = false;
		semiGun = false;

		//setting up health and shield sliders
		healthBar.enabled = false;
		healthText.text = "Health " + healthCount + "/100";
		healthBar.maxValue = healthCount;
		healthBar.value = healthCount;

		shieldBar.gameObject.SetActive (false);
		shieldBar.enabled = false;
		shieldText.text = "Shield " + shieldCount + "/100";
		shieldBar.maxValue = shieldCount;
		shieldBar.value = shieldCount;

		reticles = GetComponent<pickUpScript> ();
	

		Dead.enabled = false;
		playerScript = GetComponent<FirstPersonController> ();
	}

	void Update () 
	{
		//Swapping weapons when player has both weapons
		if (Input.GetKeyDown (KeyCode.Q) && handGun && semiGun) {
			SwitchWeapon ();
		}
	}

	//Decuction to health bar
	void HealthBar ()
	{
		healthBar.value -= 10;
		healthCount -= 10;
		healthText.text = "Health " + healthCount + "/100";
	}

	//Deduction to shield bar
	void ShieldBar ()
	{
		shieldBar.value -= 5;
		shieldCount -= 5;
		shieldText.text = "Shield " + shieldCount + "/100";
	}

	void SwitchWeapon ()
	{
		//if weapon01 is active, set it to false and set weapon02 to true
		if (weapon01.activeSelf) {
			weapon01.SetActive (false);
			weapon02.SetActive (true);
		} 
		//if weapon02 is active, set it to false and set weapon01 to true
		else {
			weapon01.SetActive (true);
			weapon02.SetActive (false);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		//if collision with shield happens, activate shield
		if (other.CompareTag ("shield")) {
			Debug.Log ("Colliding with shield");
			if (shieldBar.enabled == false) {
				shieldBar.gameObject.SetActive (true);
				shieldBar.enabled = true;
				Destroy (other.gameObject);
			} 
			else {
				shieldBar.value = 100;
				shieldCount = 100;
				shieldText.text = "Shield " + shieldCount + "/100";
				Destroy (other.gameObject);
			}
		}

		//if collision with health, increase it if its less then or equal to 75.
		if (other.CompareTag ("health")) {
			if (healthCount <= 75) {
				healthCount += 25;
				healthText.text = "Health " + healthCount + "/100";
				healthBar.value = healthCount;
				Destroy (other.gameObject);
			}
		}

		//picks up hand gun and enables it
		if (other.CompareTag ("handGun")) {
			reticles.reticle.gameObject.SetActive (true);
			reticles.reticleDot.gameObject.SetActive (true);
			handGun = true;
			weapon01.SetActive (true);
			weapon02.SetActive (false);
			Destroy (other.gameObject);
		}

		//To add secondary weapon, duplicate semiauto gun on player, delete all unecessary components
		//and add a trigger collider. tag it with semiGun. This enables swapping.
		if (other.gameObject.CompareTag ("semiGun")) {
			Debug.Log ("Colliding with semiGun");
			semiGun = true;
			weapon01.SetActive (false);
			weapon02.SetActive (true);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("enemyAx")){
			Debug.Log ("Colliding wiht the ax!");
			//if shieldBar is deactivated, deduct from health.
			if (shieldBar.enabled == false) {
				healthBar.enabled = true;
				if (healthCount > 0) {
					HealthBar ();
				}
				else if (healthCount <= 0) {
					Dead.enabled = true;
					playerScript.enabled = false;
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
			} 
			//if shieldBar is activated, deduct from shield and not health
			else {
				healthBar.enabled = false;
				if (shieldCount > 0) {
					ShieldBar ();
				} 
				else if (shieldCount <= 0){
					HealthBar ();
					shieldBar.gameObject.SetActive (false);
				}
			}
		}
	}
}
