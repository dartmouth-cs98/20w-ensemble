using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MusicPage : MonoBehaviour
{
	//Music Image
	public float smooth;
	public int pageID;
	public string pageName;
	private Vector3 targetAngle;


	// Update is called once per frame
    void Update()
    {
     	this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, targetAngle, smooth * Time.deltaTime); // lerp to new angles
    	
    }

	public void turnRight() {
		targetAngle = (180f - (float)(pageID)*5f) * Vector3.forward;

	}

	public void turnLeft() {
		targetAngle = (0f + (float)(1-pageID)*5f)*Vector3.forward;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
