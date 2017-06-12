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
    Animator anim;
	int currentAttack = 0;
	string attackAnim;
	PlayerVitals playerVitals;
	private bool cooldown;
	private float cooldownTimer = 2.0f;

    // Use this for initialization
    void Start () 
	{
		navAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		nextPoint = 0;
		isPatrolling = true;
		Player = GameObject.FindGameObjectWithTag("Player");
        //Animation stuff
        anim = GetComponent<Animator>();
		playerVitals = Player.GetComponent<PlayerVitals>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        //Animation
        anim.SetFloat("Speed", navAgent.speed);
        //End Animation
		//Attack

        //End Attack
        //Patrolling
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

		/*CAT ATTACKING*/
		//Switch between different attack animations

		if(currentAttack == 0)
		{
			attackAnim = "Big_Cat_Swipe01";
		}
		else if (currentAttack == 1)
		{
			attackAnim = "Big_Cat_Bite";						
		}
		else if (currentAttack == 2)
		{
			attackAnim = "Big_Cat_Swipe02";
		}


		if (Vector3.Distance(transform.position, playerLocation.position) < 4 && canSeePlayer() && cooldown == false) //If the cat is within range and can see the player, and attack is not on cooldown
		{
			anim.Play(attackAnim); //Play one of the three attack animations
			currentAttack = (currentAttack +1) % 3; //Change the attack animation that the cat will use next
			playerVitals.healthSlider.value -= 20; //Decrease player's health by 20
			cooldown = true; //Put attack on cooldown
		}

		if (cooldown) //If attack is on cooldown
		{
			cooldownTimer -= Time.deltaTime; //count down for two seconds
			if(cooldownTimer <= 0) //Once two seconds is up
			{
				cooldownTimer = 2.0f; //reset the cooldown timer to 2 seconds
				cooldown = false; //attack is no longer on cooldown
			}
		}


	}
    //End Patrolling This portion of the script uses pathfinding
    //Sight
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
    //End Sight This portion checks to see if you can see the player by putting out a ray and checking
    //if the player is within the fov and the range. 

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
