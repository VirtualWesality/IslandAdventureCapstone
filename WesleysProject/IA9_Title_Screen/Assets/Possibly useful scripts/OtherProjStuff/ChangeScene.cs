using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene (string SceneToChange) {
		SceneManager.LoadScene(SceneToChange);
	}
}
