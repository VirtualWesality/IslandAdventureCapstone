using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Written by: Tim Allen
/// Credit To: Holistic3dA Simple GUI Inventory, Object Pickup and Respawn in Unity 5
/// 
/// This just randomly spawns an object in a given range using a vector. It is pretty 
/// simple. Could be modified to do a couple of things.
/// </summary>
public class FruitSpawn : MonoBehaviour {
    //tells the script to expect a game object it does not need to be named fruit
    public GameObject fruit;
    //spawns the number of fruits set here
    int spawnNum = 8;
    //the spawn function
    void spawn()
    {
        //creates a fruit at the location specified by the vector and then cycles. 
        for(int i=0; i<spawnNum; i++)
        {
            Vector3 fruitPos = new Vector3(this.transform.position.x + Random.Range(-1.0f,1.0f),
                                           this.transform.position.y + Random.Range(0.0f, 2.0f),
                                           this.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(fruit, fruitPos, Quaternion.identity);
        }
    }
	// Use this for initialization
	void Start () {
        spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
