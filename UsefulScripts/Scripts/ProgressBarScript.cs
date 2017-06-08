using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBarScript : MonoBehaviour {

	public Transform loadingBar;
	public Transform textIndicator;
	public Transform textLoading;
	[SerializeField] private float currentAmmount;
	[SerializeField] private float speed = 2;

	void Update () {
		if (currentAmmount < 100) {
			currentAmmount += speed * Time.deltaTime;
			textIndicator.GetComponent<Text> ().text = ((int)currentAmmount).ToString () + "%";
			textLoading.gameObject.SetActive (true);
		}

		else {
			textLoading.gameObject.SetActive (false);
			textIndicator.GetComponent<Text> ().text = "DONE!";
		}

		loadingBar.GetComponent<Image> ().fillAmount = currentAmmount / 100;
	}
}
