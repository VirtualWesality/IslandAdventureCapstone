using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public float titleScreenTimer = 15.0f;
	
	
	// Update is called once per frame
	void Update ()
    {
        titleScreenTimer -= Time.deltaTime;

        if (titleScreenTimer <= 0)
        {
            SceneManager.LoadScene("Title");
        }
	}
}
