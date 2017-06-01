using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //CameraControlelr.cs Made by Conner Lindsley
    //for the Spring 2017 Capstone Game Project.

    public Transform target;
    public bool lockedOn = false; //Boolean used by the character controller to tell when you're locked on to something.

    [System.Serializable]
    public class PositionSettings //Class that holds basic info for the camera's position in 3d space relative to it's target.
    {
        public Vector3 targetPosOffset = new Vector3(0, 2f, 0); //Changing the origin of the character, so we don't look at it's feet.
        public float lookSmooth = 100f; //Used to smooth the movement of the camera.
        public float distanceFromTarget = -8; //Starting distance from camera target. Modified by maxZoom and minZoom.
        public float zoomSmooth = 100; //Used to smooth the zoom, so we don't all throw up.
        public float maxZoom = -2; //These modify distanceFromTarget to make the camera zoom in or out.
        public float minZoom = -15;
    }

    [System.Serializable]
    public class LockOnSettings //Class that holds the info and settings for the lock on system.
    {
        public Vector3 lockPosOffset = new Vector3(0, 0, 0); //Vector that changes the location of the camera, relative to the two targets.
        public Transform enemyTarget; //Container for the enemy's transform when you grab it from the lock on.
    }

    /* The plan is to have a vector3 between the player and target, move the camera to an offset positon that can view both target and player, and have the camera focus on the mid point
    between the two targets. Depending on where they are realative to each other, position will flip to match. (Default, Player on left, enemy on right.)

    Need to raycast or linecast (probably linecast, if it gives a vector) for available enemies relative to the camera's looking direction and distance from the player. Making the lock
    break if the target gets too far away.
    */

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
        public string LOCK_ON = "Fire2";
    }

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public InputSettings input = new InputSettings();
    public LockOnSettings lockOn = new LockOnSettings();

    private Vector3 targetPos = Vector3.zero; //Initialization of our vectors that track the camera's target, and the destination of the camera as it moves.
    private Vector3 destination = Vector3.zero;
    private Vector3 enemyPos = Vector3.zero; //Initialization of the enemy position vector, used to look at the enemy.
    private PlayerController charControl; //Reference to the PlayerController Script
    private EnemyStats enemyStat; //Reference to EnemyStats script of the target enemy
    float vOrbitInput, hOrbitInput, zoomInput, hOrbitSnapInput, lockOnInput; //Floats that hold our orbit values.

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

    public void SetCameraEnemyTarget(Transform t) //Function that initiates the actual changes to make the lock on work.
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<EnemyStats>())
            {
                enemyStat = target.GetComponent<EnemyStats>();
                Debug.Log("Got the enemy!");
            }
            else
                Debug.LogWarning("Warning: Target has no EnemyStats component!");
        }
        else
            Debug.LogWarning("There is no enemy target!");
    }

    void GetInput()
    {
        vOrbitInput = Input.GetAxisRaw(input.ORBIT_VERTICAL);
        hOrbitInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL);
        hOrbitSnapInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL_SNAP);
        zoomInput = Input.GetAxisRaw(input.ZOOM);
        lockOnInput = Input.GetAxisRaw(input.LOCK_ON);
    }

    void LateUpdate()
    {
        //moving
        MoveToTarget();
        //rotating
        if (lockedOn == false)
            LookAtTarget();
       
    }

    void Update()
    {
        GetInput();
        if(lockedOn == false)
        {
            OrbitTarget();
            ZoomOnTarget();
        }
        LockOnTarget();
    }

    void MoveToTarget() //Function that moves the camera to follow the player. WARNING: Causes the camera to rotate with the player. Need to fix that so they stay independant.
    {
        targetPos = target.position + position.targetPosOffset; //Target position calculated by the target(character)'s position and the offset vector.
        destination = Quaternion.Euler(orbit.xRot, orbit.yRot + target.eulerAngles.y, 0) * -Vector3.forward * position.distanceFromTarget; 
        destination += targetPos;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);
    }

    void LookAtEnemy(Transform enemy)
    {
        enemyPos = enemy.position;

        Quaternion enemyRotation = Quaternion.LookRotation(enemyPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, enemyRotation, position.lookSmooth * Time.deltaTime);
    }

    void LockOnTarget()
    {
        GameObject enemy = FindClosestEnemy();
        Transform enemyTrans = enemy.transform;
        Vector3 diff = enemy.transform.position - transform.position;
        float curDiff = Mathf.Abs(diff.magnitude);

        if (Input.GetAxisRaw("Mouse 2") > 0.1f && curDiff < 20f)
        {
            orbit.yRot = -180;
            orbit.xRot = -20;
            Debug.Log("Lock On " + enemy);
            LookAtEnemy(enemyTrans);
            lockedOn = true;
        }
        else
        {
            Debug.Log("Returning to " + target);
            lockedOn = false;
        }
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

    GameObject FindClosestEnemy()
    {
        GameObject[] g;
        g = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float dis = Mathf.Infinity;
        Vector3 pos = transform.position;

        Debug.Log("Starting check for ClosestEnemy");

        foreach (GameObject go in g)
        {
            Vector3 diff = go.transform.position - pos;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < dis)
            {
                closest = go;
                dis = curDistance;
            }
        }
        Debug.Log("Found " + closest.name);
        return closest;
    }
}
 