using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class MovingRaft : MonoBehaviour
{
    Vector3 PointPos;
    Transform Point;
    public float speed = 2f;
    public int arraySpot = -1;
    public GameManager gmScript;
    public GameObject Player, Ethan;
    public Raft raftScript;
    public bool arrived = true;
    

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
        if (!arrived)
        {
            TravelToIsland2(Point);
        }
        else
        { }              
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

            if (!Point)
            {
                Player.transform.position = Ethan.transform.position;
                Ethan.SetActive(false);
                Player.SetActive(true);
                arrived = true;
                Player.GetComponent<ThirdPersonUserControl>().enabled = true;
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
