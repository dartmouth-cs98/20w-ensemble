using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MusicPage : MonoBehaviour
{
	//Music Image
	public float smooth = 0.5f;

	private Vector3 targetAngle;


	// Update is called once per frame
    void Update()
    {
     	transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngle, smooth * Time.deltaTime); // lerp to new angles
    	
    }

	public void turnRight() {
		targetAngle = 180f * Vector3.forward;

	}

	public void turnLeft() {
		targetAngle = 0f*Vector3.forward;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
