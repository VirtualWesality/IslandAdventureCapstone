using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public Transform[] patrolPath;
	public bool isPatrolling;
	public Transform playerLocation;
	public float detectionRange = 10;
    public float fov = 60.0f;
    public float maxDistance = 20.0f;
    public bool PlayerSighted;
    public Vector3 PlayerLastKnown;
	private int nextPoint;
	private UnityEngine.AI.NavMeshAgent navAgent;
	GameObject Player;
    private Animator anim;


    // Use this for initialization
    void Start () {
		navAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		nextPoint = 0;
	//	navAgent.SetDestination (patrolPath [nextPoint].position);
		isPatrolling = true;
		Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //Animation
        float y= navAgent.speed;
         anim.SetFloat("Speed", y);

        //End Animation
		if (isPatrolling) {
			fov = 60.0f;
			if (Vector3.Distance(transform.position, playerLocation.position) < detectionRange && canSeePlayer()) 
			{	
				isPatrolling = false;
                
			}
			else if (navAgent.remainingDistance < .8) {
				nextPoint = (nextPoint + 1) % patrolPath.Length;
				navAgent.SetDestination (patrolPath [nextPoint].position);
			}
		} 
		else 
		{
			
			fov = 360.0f;
			if (Vector3.Distance (transform.position, playerLocation.position) > detectionRange) {	
				isPatrolling = true;
				navAgent.SetDestination (patrolPath [nextPoint].position);
			} else {
				navAgent.SetDestination (playerLocation.position);
			}
		}
	}

    bool canSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = Player.transform.position - transform.position;

		if ((Vector3.Angle(rayDirection, transform.right)) <= fov)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, maxDistance))
            {
				Debug.Log (hit.transform.gameObject);
                if (hit.transform.CompareTag("Player")) { return true; }
            }
        }
        return false;
    }


    /*Ray click = Camera.main.ScreenPointToRay (Input.mousePosition);
    RaycastHit hit;

    if (Input.GetButtonDown("Fire1"))
    {
        if (Physics.Raycast(click, out hit, 1000))
        {
            navAgent.SetDestination (hit.point);
        }
    }*/

}
