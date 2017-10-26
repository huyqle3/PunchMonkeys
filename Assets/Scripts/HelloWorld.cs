using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HelloWorld : MonoBehaviour {
    public GameObject myCamera;
    public GameObject myHands;
   // public HandMod
	// Use this for initialization
	void Start () {
        Debug.Log("hello world from Liao on Start()");
        // Wrong code: it means this->GetComponent <>, not searching from top level!
        // myCamera = GetComponent<Camera>();
        myCamera = GameObject.Find("Camera");

        if (myCamera)
        {
            Debug.Log("Found the camera");
            myHands=myCamera.GetComponent<HandModels>();
    
        }
        else
        {
            Debug.Log("Not found the camera");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
