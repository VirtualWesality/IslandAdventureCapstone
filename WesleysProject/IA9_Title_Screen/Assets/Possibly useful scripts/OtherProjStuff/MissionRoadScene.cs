using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionRoadScene : MonoBehaviour {

	public Text mission;

	// Use this for initialization
	void Start () {
		mission.enabled = true;
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			mission.enabled = false;
		}
	}
}
