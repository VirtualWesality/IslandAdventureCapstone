using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] sailingSpots, sailingSpotsIsland2;
    public float numberOfSailingSpots;
    public Transform currentTransform;

	// Use this for initialization
	void Start ()
    {
        numberOfSailingSpots = sailingSpots.Length;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Transform setNextSailingSpot(int currentSalingSpot)
    {
        int whatIn;

        if (currentSalingSpot < numberOfSailingSpots)
        {
            whatIn = (currentSalingSpot + 1);
            currentTransform = sailingSpots[whatIn];
        }
        else
        {
            currentTransform = null;
        }

        return currentTransform;
    }
}
