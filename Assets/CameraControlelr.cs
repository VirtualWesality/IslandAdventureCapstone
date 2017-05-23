using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlelr : MonoBehaviour {

    //CameraControlelr.cs Made by Conner Lindsley
    //for the Spring 2017 Capstone Game Project.

    public Transform target;

    [System.Serializable]
    public class PositionSettings //Class that holds basic info for the camera's position in 3d space relative to it's target.
    {
        public Vector3 targetPosOffset = new Vector3(0, .5f, 0); //Changing the origin of the character, so we don't look at it's feet.
        public float lookSmooth = 100f; //Used to smooth the movement of the camera.
        public float distanceFromTarget = -8; //Starting distance from camera target. Modified by maxZoom and minZoom.
        public float zoomSmooth = 100; //Used to smooth the zoom, so we don't all throw up.
        public float maxZoom = -2; //These modify distanceFromTarget to make the camera zoom in or out.
        public float minZoom = -15;
    }

    [System.Serializable]
    public class OrbitSettings //Class that holds the orbit and rotation setting for the camera, relative to the target.
    {
        public float xRot = -20; //Forced rotation of the camera as it zips around the character (Orbits the character.)
        public float yRot = -180;
        public float maxXRot = 25; //These two are used to make sure that the camera doesn't go underground or out of the range of the character. (Not upside down)
        public float minXRot = -85;
        public float vOrbitSmooth = 150; //More smoothing values for the changes.
        public float hOrbitSmooth = 150;
    }

    [System.Serializable]
    public class InputSettings //Class that adds special input axis for the camera controls.
    {
        public string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
        public string ORBIT_HORIZONTAL = "OrbitHorizontal";
        public string ORBIT_VERTICAL = "OrbitVertical";
        public string ZOOM = "Mouse Scrollwheel";
    }

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public InputSettings input = new InputSettings();

    private Vector3 targetPos = Vector3.zero; //Initialization of our vectors that track the camera's target, and the destination of the camera as it moves.
    private Vector3 destination = Vector3.zero;
    private PlayerController charControl; //Reference to the PlayerController Script
    float vOrbitInput, hOrbitInput, zoomInput, hOrbitSnapInput; //Floats that hold our orbit values.

    void Start()
    {
        SetCameraTarget(target);

        targetPos = target.position + position.targetPosOffset;
        destination = Quaternion.Euler(orbit.xRot, orbit.yRot + target.eulerAngles.y, 0) * -Vector3.forward * position.distanceFromTarget;
        destination += targetPos;
        transform.position = destination;
    }

    public void SetCameraTarget(Transform t)
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<PlayerController>())
            {
                charControl = target.GetComponent<PlayerController>();
            }
            else
                Debug.LogError("The camera's target needs a character controller!");
        }
        else
            Debug.LogError("Your camera needs a target!");
    }

    void GetInput()
    {
        vOrbitInput = Input.GetAxisRaw(input.ORBIT_VERTICAL);
        hOrbitInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL);
        hOrbitSnapInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL_SNAP);
        zoomInput = Input.GetAxisRaw(input.ZOOM);
    }

    void LateUpdate()
    {
        //moving
        MoveToTarget();
        //rotating
        LookAtTarget();
    }

    void Update()
    {
        GetInput();
        OrbitTarget();
        ZoomOnTarget();
    }

    void MoveToTarget()
    {
        targetPos = target.position + position.targetPosOffset;
        destination = Quaternion.Euler(orbit.xRot, orbit.yRot + target.eulerAngles.y, 0) * -Vector3.forward * position.distanceFromTarget;
        destination += targetPos;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);
    }

    void OrbitTarget() //Function that handles the actual orbiting of the camera around the player
    {
        if (hOrbitSnapInput > 0) //Check to see if the snap button was pressed, and snaps the camera behind the player.
        {
            orbit.yRot = -180;
        }

        orbit.xRot += -vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime; //Calculations of the rotations based on the input, the smoothing value, and time of course,
        orbit.yRot += -hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;

        if (orbit.xRot > orbit.maxXRot) //Upper bounds checking
        {
            orbit.xRot = orbit.maxXRot;
        }
        
        if(orbit.xRot < orbit.minXRot) //Lower bounds checking
        {
            orbit.xRot = orbit.minXRot;
        }
    }

    void ZoomOnTarget()
    {
        position.distanceFromTarget += zoomInput * position.zoomSmooth * Time.deltaTime;

        if(position.distanceFromTarget > position.maxZoom)
        {
            position.distanceFromTarget = position.maxZoom;
        }

        if(position.distanceFromTarget < position.minZoom)
        {
            position.distanceFromTarget = position.minZoom;
        }
    }
}
 