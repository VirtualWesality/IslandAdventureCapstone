using UnityEngine;
using System.Collections;

public class AddForceToZombie : MonoBehaviour {

	public int forceToZombie;
	public Health zombieHealth;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "enemy") {
			//col.rigidbody.AddForce (Vector3.forward * forceToZombie, ForceMode.Impulse);
			zombieHealth.hit();
		}
	}
}
