using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
