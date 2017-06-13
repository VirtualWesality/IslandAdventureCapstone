using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerVitals : MonoBehaviour {

    public Slider healthSlider, thirstSlider, hungerSlider;
    public int maxHealth, healthFallRate, healthGainRate;
    public float maxThirst, thirstFallRate;
    public float maxHunger, hungerFallRate;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        thirstSlider.maxValue = maxThirst;
        thirstSlider.value = maxThirst;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;
    }

    private void Update()
    {
        //Health Controller
        if (hungerSlider.value <= 0 && (thirstSlider.value <= 0))
        {
            healthSlider.value -= Time.deltaTime / healthFallRate * 2;
        }
        else if (hungerSlider.value <= 0 || thirstSlider.value <= 0)
        {
            healthSlider.value -= Time.deltaTime / healthFallRate;
        }
		else if (hungerSlider.value >= 50 && thirstSlider.value >= 50 && healthSlider.value < maxHealth)
		{
			healthSlider.value += Time.deltaTime / healthGainRate;
		}


        if (healthSlider.value <= 0)
        {
            CharacterDeath();
        }

        //Hunger Controller
        if (hungerSlider.value >= 0)
        {
            hungerSlider.value -= Time.deltaTime / hungerFallRate;
        }
        else if (hungerSlider.value <= 0)
        {
            hungerSlider.value = 0;
        }
        else if (hungerSlider.value >= maxHunger)
        {
            hungerSlider.value = maxHunger;
        }

        //Thirst Controller
        if (thirstSlider.value >= 0)
        {
            thirstSlider.value -= Time.deltaTime / thirstFallRate;
        }
        else if (thirstSlider.value <= 0)
        {
            thirstSlider.value = 0;
        }
        else if (thirstSlider.value >= maxThirst)
        {
            thirstSlider.value = maxThirst;
        }
    }

    void CharacterDeath()
    {
        //Do something death related
		SceneManager.LoadScene("Title");
	}

    public void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Lava")
        {
            healthSlider.value -= 0.5f;
        }

        if (other.GetComponent<Collider>().tag == "FreshWater")
        {
            thirstSlider.value += 0.5f;
        }
    }

}
