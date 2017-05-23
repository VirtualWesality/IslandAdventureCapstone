using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //PlayerController.cs Made by Conner Lindsley
    // for the Spring 2017 Capstone Game Project.

    public float inputDelay = 0.1f; //Just for the feels
    public float forwardVel = 12; //Base Velocity
    public float rotateVel = 100; //Base rotation

    private Quaternion targetRotation; //Rotation containter.
    private Rigidbody rBody; 
    private float forwardInp, turnInp; //Inputs

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
        forwardInp = Input.GetAxis("Vertical");
        turnInp = Input.GetAxis("Horizontal");
    }

	
	void Update ()
    {
        GetInput();
        Turn();
	}

    private void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        if (Mathf.Abs(forwardInp) > inputDelay)
        {
            //Move
            rBody.velocity = transform.forward * forwardInp * forwardVel; //forwardInp can be positive or negative, which is why we need the absolute value.
        }
        else
            //zero velocity
            rBody.velocity = Vector3.zero;
    }

    void Turn()
    {
        if (Mathf.Abs(turnInp) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInp * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

}
