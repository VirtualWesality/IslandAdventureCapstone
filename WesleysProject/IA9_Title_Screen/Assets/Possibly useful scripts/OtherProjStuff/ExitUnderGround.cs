using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitUnderGround : MonoBehaviour {

	//LoadScene sendToLoading;

	void Start ()
	{
		//sendToLoading = GetComponent<LoadScene> ();
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			//sendToLoading.LoadSceneNum (3);
		}
	}

}
