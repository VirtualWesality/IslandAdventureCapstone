using UnityEngine;
using System.Collections;

public class LabDoorsScript : MonoBehaviour {

	Animator doorsAnim;
	bool isOpen;

	void Start () 
	{
		isOpen = false;
		doorsAnim = GetComponent<Animator> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			isOpen = true;
			Doors ("Open");
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (isOpen)
		{
			isOpen = false;
			Doors ("Close");
		}
	}

	void Doors (string direction)
	{
		doorsAnim.SetTrigger (direction);
	}
}
