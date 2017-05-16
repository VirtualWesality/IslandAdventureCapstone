using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToExitScene : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Credits");
		}
	}
}
