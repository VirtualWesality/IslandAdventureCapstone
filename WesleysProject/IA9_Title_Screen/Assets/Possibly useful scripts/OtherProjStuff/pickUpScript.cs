using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityStandardAssets.Characters.FirstPerson;

public class pickUpScript : MonoBehaviour {
    /*
	public Text magText;
	public int numMags;
	public RaycastShoot numAmmo01;
	public RaycastShoot numAmmo02;

	WeaponSwap gun;

	public Slider barAmmo01;
	public Slider barAmmo02;

	public Image reticle;
	public Image reticleDot;

	public Canvas tutorial;
	//FirstPersonController player;

	public GameObject paused;

	void Start () {
		numMags = 0;
		magText.text = "X " + numMags;

		gun = GetComponent<WeaponSwap> ();

		reticle.gameObject.SetActive (false);
		reticleDot.gameObject.SetActive (false);

		Time.timeScale = 0;
		tutorial.enabled = true;
		//player = GetComponent<FirstPersonController> ();
		//player.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (paused.activeSelf == false) {
			if (Input.GetKeyDown (KeyCode.T)) {
				if (tutorial.enabled) {
					Time.timeScale = 1;
					player.enabled = true;
				} else {
					Time.timeScale = 0;
					player.enabled = false;
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
				tutorial.enabled = !tutorial.enabled;
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			if (numMags > 0) {
				if (gun.weapon01.activeSelf && numAmmo01.ammoCount01 < 10) {
					barAmmo01.value = 10;
					numAmmo01.ammoCount01 = 10;
					numAmmo01.ammoText01.text = "Ammo " + numAmmo01.ammoCount01 + "/10";
					numMags--;
					magText.text = "X " + numMags;
				} 
				else if (gun.weapon02.activeSelf && numAmmo02.ammoCount02 < 30) {
					barAmmo02.value = 30;
					numAmmo02.ammoCount02 = 30;
					numAmmo02.ammoText02.text = "Ammo " + numAmmo02.ammoCount02 + "/30";
					numMags--;
					magText.text = "X " + numMags;
				} 
				else {
					Debug.Log ("Full of ammo, can't reload");
				}
			}
			else {
				magText.text = "=(";
			}
		} 

		if (Input.GetButtonDown ("Fire3") && (gun.handGun || gun.semiGun)){
			reticle.enabled = !reticle.enabled;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("ammo")) {
			numMags++;
			magText.text = "X " + numMags;
			Destroy (other.gameObject);
		}
	}
    */
}
