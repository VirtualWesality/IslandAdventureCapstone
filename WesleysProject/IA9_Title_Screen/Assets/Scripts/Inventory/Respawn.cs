using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    /// <summary>
    /// Written by: Tim Allen
    /// Credit To: Holistic3dA Simple GUI Inventory, Object Pickup and Respawn in Unity 5
    /// 
    /// Doesn't do much but it does set an object at its position to false in the game world
    /// which will render it invisible after a given amount of time in this case 5 seconds
    /// it will reinstansiate at the position it was before. Need to think of a way to randomize
    /// this. 
    /// </summary>

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        Invoke("Respawn_1", 5);
    }
    void Respawn_1()
    {
        this.GetComponent<SphereCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
