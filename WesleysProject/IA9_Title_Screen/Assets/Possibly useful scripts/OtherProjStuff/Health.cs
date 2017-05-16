using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float hp;

	Animator zombieAnim;
	Navigation zombieNavigate;
	CapsuleCollider zombieCol;

	void Start () 
	{
		hp = 100;

		zombieAnim = GetComponent<Animator> ();
		zombieAnim.SetBool ("idle0ToRun", true);

		zombieNavigate = GetComponent<Navigation> ();
	}

	public void hit () 
	{
		hp -= 20;

		if (hp <= 0) 
		{
			zombieAnim.SetBool ("runToIdle0", true);
			zombieAnim.SetBool ("idle0ToRun", false);
			zombieAnim.SetBool ("idle0ToDeath", true);
			zombieNavigate.enabled = false;
			Destroy (gameObject, 5);
		}
	}
}
