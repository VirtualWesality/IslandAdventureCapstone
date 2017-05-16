using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionScript : MonoBehaviour {

	public Text mission;

	void Start ()
	{
		mission.gameObject.SetActive (false);
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			mission.gameObject.SetActive (true);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player"){
			mission.gameObject.SetActive (false);
		}
	}
}
