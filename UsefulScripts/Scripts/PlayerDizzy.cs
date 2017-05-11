using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDizzy : MonoBehaviour {

	public FirstPersonController player;

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			player.m_WalkSpeed = 3;
			player.m_RunSpeed = 3;
			player.m_MouseLook.smooth = true;
			player.m_MouseLook.smoothTime = 2f;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			player.m_WalkSpeed = 10;
			player.m_RunSpeed = 20;
			player.m_MouseLook.smooth = false;
			player.m_MouseLook.smoothTime = 5f;
		}
	}
}
