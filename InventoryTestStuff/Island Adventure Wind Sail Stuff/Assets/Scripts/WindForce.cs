using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class WindForce : MonoBehaviour {
    /// <summary>
    /// Written by: Tim Allen
    /// Credit to: Nathan Harris
    /// 
    /// In short this is a first pass at a random wind generation system that would be 
    /// used for sailing. It is not done and is more of a pet project feel free to poke 
    /// around though. Basically windDirection*WindSpeed=WindForce and the rest is 
    /// getting it to change once in a random interval to a random strength. There is more 
    /// here but it will take some time to flesh out. This is not a fun script do not attempt
    /// unless your level is apprenticed wizard or higher.
    /// 
    /// </summary>

    //wind direction
    public float windDirection = 0.0f;
    //wind speed
    public float windSpeed = 0.0f;
    //wind force
    public float windForce = 0.0f;
    //has the wind been changed?
    public bool windChanged = false;
    //new wind direction
    public float newWindDir = 0.0f;
    //new wind speed
    public float newWindSpd = 0.0f;
    //wind transition time
    public float windTransTime = 0.0f;
    //temp new force
    public float newForce = 0.0f;
    //time t
    static float t = 0.0f;
    //stuff about a boat
    public GameObject boat;
    // This comment is a lie //Use this for initialization
    void Start() {
        boat = GameObject.Find("Boat");
    }


//unity's logs are stupid.
    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.ActiveEditorTracker));
        var type = assembly.GetType("UnityEditorInternal.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    //this will change the wind it takes in the new direction, speed, and transition time.
    public void changeWind(float newDir, float newSpeed, float transitionTime)
    {
        newWindDir = newDir;
        newWindSpd = newSpeed;
        windTransTime = transitionTime*60.0f;
        windChanged = false;
        
    }


    //this updates the wind and then sets wind changed equal to true. it also spins a box but this
    //is a secret so shhhh
    public void updateWind()
    {
        newForce = newWindDir * newWindSpd;
        var rot = boat.transform.rotation;
        t += Time.deltaTime;

        if (t >= windTransTime)
        {
            t = 0.0f;
        }
        
        windForce = Mathf.Lerp(windForce, newForce, Time.deltaTime);
        if (windForce>360.0f)
        {
            windForce = 360.0f;
        }
        if (windForce == newForce)
        {
            windChanged = true;
            Debug.Log("WIND CHANGED SUCCESS");
            
        }
        else
        {
            windChanged = false;
            
            boat.transform.rotation = rot * Quaternion.Euler(0, windForce, 0);

        }
    }
    //this updates every frame.... if you press w shit changes between the numbers listed. Yes, I am getting tired. 
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            changeWind(Random.Range(5.0f, 30.0f), Random.Range(1.0f, 10.0f), Random.Range(3.0f, 5.0f));
           
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            boat.transform.Rotate(Vector3.up, Time.deltaTime*60.0f);

        }
        if (!windChanged)
        {
            updateWind();
            
        }

         Debug.Log("windChanged: " + windChanged);
         Debug.Log("windForce: " + windForce);
         Debug.Log("windTransTime: " + windTransTime);
         Debug.Log("newWindSpd: " + newWindSpd);
         Debug.Log("newWindDir: " + newWindDir);
         Debug.Log("windDirection: " + windDirection);
       
        //Debug.ClearDeveloperConsole();
        //ClearLog();


    }
}
