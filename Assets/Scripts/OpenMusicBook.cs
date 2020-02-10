using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenMusicBook : MonoBehaviour
{
	[SerializeField] Button openButton;
	private Vector3 rotation; 
	private bool isOpenClicked;
    // Start is called before the first frame update
    void Start()
    {
        if(openButton != null) {
        	openButton.onClick.AddListener(() => openButton_Click());
        }
    }

    // Update is called once per frame
    void Update(){
    	if(isOpenClicked) {
    		transform.Rotate(rotation * Time.deltaTime);
    	}
        
    }

    private void openButton_Click() {
    	isOpenClicked = true;
    	rotation = new Vector3(0,180,0);
    }

}
