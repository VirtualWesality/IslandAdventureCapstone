using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PickUpRoadScene : MonoBehaviour {

	public Text magText;
	public int numMags;
	public RaycastShoot numAmmo01;
	public RaycastShoot numAmmo02;

	WeaponSwapRoadScene gun;

	public Slider barAmmo01;
	public Slider barAmmo02;

	public Image reticle;

	FirstPersonController player;

	public GameObject paused;

	void Start () {
		numMags = 0;
		magText.text = "X " + numMags;

		gun = GetComponent<WeaponSwapRoadScene> ();

		reticle.gameObject.SetActive (true);
	
		player = GetComponent<FirstPersonController> ();
		player.enabled = true;
	}

	// Update is called once per frame
	void Update () {

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

		if (Input.GetButtonDown ("Fire3")){
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
}
