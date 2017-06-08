using UnityEngine;
using System.Collections;

public class zombieAttack : MonoBehaviour {

	Animator zombieAnim;
	Navigation ZombieNav;

	void Start ()
	{
		zombieAnim = GetComponentInParent<Animator> ();
		ZombieNav = GetComponentInParent<Navigation> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player") && !ZombieNav.isPatrolling){
			zombieAnim.SetBool ("idle0ToRun", false);
			zombieAnim.SetBool ("runToIdle0", true);
			zombieAnim.SetBool ("idle0ToAttack0", true);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")){
			zombieAnim.SetBool ("idle0ToRun", true);
			zombieAnim.SetBool ("idle0ToAttack0", false);
			zombieAnim.SetBool ("runToIdle0", false);
		}
	}
}
