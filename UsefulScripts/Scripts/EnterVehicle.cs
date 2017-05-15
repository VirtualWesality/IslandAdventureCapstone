using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehicle : MonoBehaviour {
	public GameObject Vehicle;
	public GameObject Player;
	public GameObject PlayerBackup;
	private bool inVehicle = false;
	CarUserControl vehicleScript;
	public Text enterText;
	public Camera carCam;

	public GameObject reticle;
	public GameObject reticleDot;


	void Start () {
		vehicleScript = GetComponent<CarUserControl>();
		vehicleScript.enabled = false;
		enterText.gameObject.SetActive(false);
		PlayerBackup.gameObject.SetActive(false);
		carCam.gameObject.SetActive (false);
	}
		
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player" && inVehicle == false)
		{
			enterText.gameObject.SetActive(true);
		}
		if (other.gameObject.tag == "Player" && inVehicle == false && Input.GetKey(KeyCode.E))
		{
			Debug.Log ("Trying to access car");
			enterText.gameObject.SetActive(false);
			PlayerBackup.gameObject.SetActive(true);
			Player.gameObject.SetActive(false);
			Player.transform.parent = Vehicle.transform;
			vehicleScript.enabled = true;
			inVehicle = true;

			carCam.gameObject.SetActive (true);

			reticle.gameObject.SetActive (false);
			reticleDot.gameObject.SetActive (false);
		}       
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			enterText.gameObject.SetActive(false);
		}
	}

	void Update()
	{
		if (inVehicle == true && Input.GetKey(KeyCode.F))
		{
			Player.SetActive(true);
			Player.transform.parent = null;
			PlayerBackup.SetActive(false);
			vehicleScript.enabled = false;
			inVehicle = false;

			reticle.gameObject.SetActive (true);
			reticleDot.gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "enemy") {
			
		}
	}
}