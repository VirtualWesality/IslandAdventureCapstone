using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //PlayerController.cs Made by Conner Lindsley
    // for the Spring 2017 Capstone Game Project.

    public Transform camera; //Reference to the main camera, so I can get it's direction values.

    //Motor control settings, make a private class?
    private Quaternion targetRotation; //Rotation angle that holds the end target for the rotation.
    private Rigidbody rBody; //Reference to the rigidbody of the character.
    private float forwardInp, turnInp; //Inputs

    [System.Serializable]
    public class ControlSettings //Base character settings class
    {
        public float inputDelay = 0.1f; //Just for the feels, adds a tiny deadzone to all inputs to normalize the feeling of them all.
        public float forwardVel = 12; //Base Velocity
        public float rotateVel = 100; //Base rotation speed
    }

    [System.Serializable]
    public class PlayerStats //Class that holds stat point values for the player, may push to a different script later?
    {
        public int maxHealth = 100; //Player's max Health
        public int currentHealth = 100; //Player's current health.
        public float maxHydration = 100.0f; //Max hydration.
        public float currentHydration = 100.0f; //Player's current water total.
        public float maxHunger = 100.0f; //Max foodies.
        public float currentHunger = 100.0f; //Current hunger.
    }

    public ControlSettings settings = new ControlSettings();
    public PlayerStats stats = new PlayerStats();

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

	void Start ()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The Character need a Rigidbody!");

        forwardInp = turnInp = 0;
	}
	
    void GetInput()
    {
        forwardInp = Input.GetAxis("Vertical") + Input.GetAxis("Horizontal");
        turnInp = Input.GetAxis("Horizontal");
    }

	
	void Update ()
    {
        GetInput();
        //Turn();
	}

    private void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        if (Mathf.Abs(forwardInp) > settings.inputDelay)
        {
            //Move
            rBody.velocity = camera.forward * forwardInp * settings.forwardVel; //forwardInp can be positive or negative, which is why we need the absolute value.
        }
        else
            //zero velocity
            rBody.velocity = Vector3.zero;
    }

    void Turn()
    {
        if (Mathf.Abs(turnInp) > settings.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(settings.rotateVel * turnInp * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

}
