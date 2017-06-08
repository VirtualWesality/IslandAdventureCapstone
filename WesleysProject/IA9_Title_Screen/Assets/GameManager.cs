using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] sailingSpots, sailingSpotsIsland2;
    public float numberOfSailingSpots;
    public Transform currentTransform;
    public int currentIsland = 1;

	// Use this for initialization
	void Start ()
    {
        numberOfSailingSpots = sailingSpots.Length;
        //Debug.Log("Sailing Spots length: "+ sailingSpots.Length);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Transform setNextSailingSpot(int currentSailingSpot)
    {

        if (currentSailingSpot < numberOfSailingSpots)
        {
            //Debug.Log("Current sailing spot: " + currentSailingSpot);
            //Debug.Log("Num sailing spots: " + numberOfSailingSpots);
            currentTransform = sailingSpots[currentSailingSpot];
        }
        else
        {
            currentTransform = null;
        }

        return currentTransform;
    }

    public Transform setNextIsland2SailingSpot(int sailSpot)
    {
        
        if (sailSpot < numberOfSailingSpots)
        {
            
            currentTransform = sailingSpotsIsland2[sailSpot];
        }
        else
        {
            currentTransform = null;
        }

        return currentTransform;
    }
}
