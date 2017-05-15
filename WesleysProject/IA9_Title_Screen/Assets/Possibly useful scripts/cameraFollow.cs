using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	//Camera follows player to create a minimap as the player moves around

	public  Transform target;

	void LateUpdate ()
	{
		transform.position = new Vector3 (target.position.x, target.position.y, target.position.z);
	}
}
