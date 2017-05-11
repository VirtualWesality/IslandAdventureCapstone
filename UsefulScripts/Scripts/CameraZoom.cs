using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraZoom : MonoBehaviour {

	//Reticle zoom in when weapons are activated.

	public int zoom = 20;
	public int normal = 60;
	public float smooth = 5;

	private bool isZoomed = false;

	FirstPersonController zoomSense;

	void Start ()
	{
		zoomSense = GetComponentInParent<FirstPersonController> ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire2")) 
		{
			isZoomed = !isZoomed;
		}

		if (isZoomed) {
			GetComponent<Camera> ().fieldOfView = Mathf.Lerp 
				(GetComponent<Camera> ().fieldOfView, zoom, Time.deltaTime * smooth);
			zoomSense.m_MouseLook.XSensitivity = 0.5f;
			zoomSense.m_MouseLook.YSensitivity = 0.5f;
		}

		else{
			GetComponent<Camera> ().fieldOfView = Mathf.Lerp 
				(GetComponent<Camera> ().fieldOfView, normal, Time.deltaTime * smooth);
			zoomSense.m_MouseLook.XSensitivity = 2;
			zoomSense.m_MouseLook.YSensitivity = 2;
		}
	}
}
