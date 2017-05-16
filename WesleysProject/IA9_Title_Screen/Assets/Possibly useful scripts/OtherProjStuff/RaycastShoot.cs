using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaycastShoot : MonoBehaviour {

	public int gunDamage = 1;                             
	public float fireRate = .25f;                                      
	public float weaponRange = 50f;                                     
	public float hitForce = 100f;                                   
	public Transform gunEnd;     

	private Camera fpsCam;                                       
	private WaitForSeconds shotDuration = new WaitForSeconds(.05f);
	private AudioSource gunAudio;                                      
	private LineRenderer laserLine;                                     
	private float nextFire;  

	public Slider ammoBar01;
	public Slider ammoBar02;
	public Text ammoText01;
	public Text ammoText02;
	public int ammoCount01;
	public int ammoCount02;

	Animator gunAnim;

	public PickUpRoadScene magsCount;

	void Start () 
	{
		ammoBar01.gameObject.SetActive (false);
		ammoBar02.gameObject.SetActive (false);

		ammoCount01 = 10;
		ammoCount02 = 30;
		ammoText01.text = "Ammo " + ammoCount01 + "/10";
		ammoText02.text = "Ammo " + ammoCount02 + "/30";
		ammoBar01.maxValue = ammoCount01;
		ammoBar02.maxValue = ammoCount02;
		ammoBar01.value = ammoCount01;
		ammoBar02.value = ammoCount02;

		laserLine = GetComponent<LineRenderer>();
		gunAudio = GetComponent<AudioSource>();

		fpsCam = GetComponentInParent<Camera>();

		gunAnim = GetComponentInParent<Animator> ();
	}


	void Update ()
	{

		if (gameObject.tag == "weapon01") { 
			ammoBar01.gameObject.SetActive (true);
			ammoBar02.gameObject.SetActive (false);

			if (Input.GetKeyDown (KeyCode.R)) {
				Guns ("reload");
			}

			if (ammoCount01 > 0 && Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
					Guns ("shoot");

				ammoBar01.value--;
				ammoCount01--;
				ammoText01.text = "Ammo " + ammoCount01 + "/10";

				nextFire = Time.time + fireRate;

				StartCoroutine (ShotEffect ());	

				Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.8f, 0.5f, 0.0f));

				RaycastHit hit;

				laserLine.SetPosition (0, gunEnd.position);

				if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange)) { 
					Debug.Log (hit.collider.gameObject);

					if (hit.collider.tag == "enemy") {
						Health hp = hit.collider.gameObject.GetComponent <Health> ();
						hp.hit ();
					}

					laserLine.SetPosition (1, hit.point);
				} else {
					laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
				}
			}
		}

		if (gameObject.tag == "weapon02") { 
			ammoBar01.gameObject.SetActive (false);
			ammoBar02.gameObject.SetActive (true);

			if (Input.GetKeyDown (KeyCode.R)) {
				Guns ("semiReload");
			}

			if (ammoCount02 > 0 && Input.GetButton ("Fire1") && Time.time > nextFire) {
					Guns ("semiShoot");

				ammoBar02.value--;
				ammoCount02--;
				ammoText02.text = "Ammo " + ammoCount02 + "/30";

				nextFire = Time.time + fireRate;

				StartCoroutine (ShotEffect ());	

				Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.8f, 0.5f, 0.0f));

				RaycastHit hit;

				laserLine.SetPosition (0, gunEnd.position);

				if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange)) { 
					Debug.Log (hit.collider.gameObject);

					if (hit.collider.tag == "enemy") {
						Health hp = hit.collider.gameObject.GetComponent <Health> ();
						hp.hit ();
					}

					laserLine.SetPosition (1, hit.point);
				} else {
					laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
				}
			}
		}
	}

	private IEnumerator ShotEffect()
	{
		gunAudio.Play ();

		laserLine.enabled = true;
	
		yield return shotDuration;

		laserLine.enabled = false;
	}

	void Guns (string action)
	{
		gunAnim.SetTrigger (action);
	}
}