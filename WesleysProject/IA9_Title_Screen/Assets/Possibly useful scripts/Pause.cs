using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    /*
	GameObject[] pause;

	public FirstPersonController player;

	public Canvas tutorialActive;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pause = GameObject.FindGameObjectsWithTag ("pause");
		hidePaused ();
		player.enabled= true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!tutorialActive.enabled) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				if (Time.timeScale == 1) {
					Time.timeScale = 0;
					showPaused ();
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					player.enabled = false;
				} else if (Time.timeScale == 0) {
					Debug.Log ("hello");
					Time.timeScale = 1;
					hidePaused ();
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
					player.enabled = true;
				}
			}
		}
	}

	public void Reload(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void pauseControl(){
		if(Time.timeScale==1){
			Time.timeScale = 0;
			showPaused ();
		} else if (Time.timeScale==0){
			Time.timeScale = 1;
			hidePaused ();
		}
	}
	public void showPaused(){
		foreach(GameObject g in pause){
			g.SetActive(true);
		}
	}
		public void hidePaused(){
			foreach(GameObject g in pause){
			g.SetActive (false);
		}
	}
	public void LoadLevel(string level){
		SceneManager.LoadScene (level);
	}
	public void Resume(){
		Time.timeScale = 1;
		hidePaused ();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		player.enabled= true;
	}
	public void ExitGame(){
		Application.Quit();
	}
    */
}






