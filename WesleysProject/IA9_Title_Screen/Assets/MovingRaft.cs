using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class MovingRaft : MonoBehaviour
{
    Vector3 PointPos;
    public Transform Point;
    public float speed = 2f;
    public int arraySpot = 0;
    public GameManager gmScript;
    public GameObject Player, Ethan;
    public Raft raftScript;
    public GameObject Test;
    

	// Use this for initialization
	void Start ()
    {
        Point = gmScript.setNextSailingSpot(arraySpot);
        Player.gameObject.SetActive(false);
        raftScript.leaveIslandText.SetActive(false);
        Ethan.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Only call this on NOT arrived
        if (gmScript.currentIsland == 1)
        {
            TravelToIsland2(Point);
        }
        else if (gmScript.currentIsland == 2)
        {
            TravelToIsland3(Point);
        }
        else if (gmScript.currentIsland == 3)
        {
            //Roll Credits baby!
        }
              
        //Player.transform.position = raftScript.playerSpawn.transform.position;
    }

    public void TravelToIsland2(Transform currentPoint)
    {
        
        PointPos = currentPoint.transform.position;

        if (!(transform.position == PointPos))
        {
            transform.position = Vector3.MoveTowards(transform.position, PointPos, speed * Time.deltaTime);
            directionToLook(Point);
        }
        else
        {
            arraySpot += 1;
            Point = gmScript.setNextSailingSpot(arraySpot);

            if (Point == null)
            {
                this.enabled = false;
                Player.transform.position = Test.transform.position;
                Ethan.SetActive(false);
                Player.SetActive(true);
                
                //arraySpot = -1;
                //Point = gmScript.setNextIsland2SailingSpot(arraySpot);
                gmScript.currentIsland++;
                Debug.Log("It's lit");
                
            }
        }
    }

    public void TravelToIsland3(Transform currentPoint)
    {
        PointPos = currentPoint.transform.position;

        if (!(transform.position == PointPos))
        {
            transform.position = Vector3.MoveTowards(transform.position, PointPos, speed * Time.deltaTime);
            directionToLook(Point);
        }
        else
        {
            arraySpot += 1;
            Debug.Log("Island2 arraySpot: " + arraySpot);
            Point = gmScript.setNextIsland2SailingSpot(arraySpot);

            if (Point == null)
            {
                this.enabled = false;
                Player.transform.position = Test.transform.position;
                Ethan.SetActive(false);
                Player.SetActive(true);
                gmScript.currentIsland++;               
            }
        }
    }

    public void directionToLook(Transform currentpoint)
    {
        if (!(transform.position == currentpoint.transform.position))
        {
            Quaternion targetRotation = Quaternion.LookRotation(currentpoint.position - transform.position);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 1);
        }
    }
}
