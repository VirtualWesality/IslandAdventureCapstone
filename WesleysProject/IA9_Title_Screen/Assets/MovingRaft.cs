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
    public GameObject ethan;
    public GameObject Player;
    public Raft raftScript;
    

	// Use this for initialization
	void Start ()
    {
        Point = gmScript.setNextSailingSpot(arraySpot);
        Player.GetComponent<ThirdPersonUserControl>().enabled = true;
        raftScript.leaveIslandText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        TravelToIsland2(Point);
        Player.transform.position = raftScript.playerSpawn.transform.position;
    }

    public void TravelToIsland2(Transform currentPoint)
    {
        PointPos = currentPoint.transform.position;

        if (!(transform.position == PointPos))
        {
            transform.position = Vector3.MoveTowards(transform.position, PointPos, speed * Time.deltaTime);
        }
        else
        {
            arraySpot += 1;
            Point = gmScript.setNextSailingSpot(arraySpot);

            if (!Point)
            {
                if (SceneManager.GetActiveScene().name == "Island1")
                { SceneManager.LoadScene("IslandTwoElectricBoogaloo"); }
            }
        }
    }
}
