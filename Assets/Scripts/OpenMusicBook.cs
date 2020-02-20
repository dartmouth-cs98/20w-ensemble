using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenMusicBook : MonoBehaviour
{
    private bool isOpen;
    public float smooth = 0.5f;
 
    private Vector3 targetAngles;

    List<GameObject> pages;
    int leftPage = -1;
    int rightPage = -1;

    Transform currentTransform;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        pages = new List<GameObject>();
        foreach (Transform child in transform){
            pages.Add(child.gameObject);
            //child is your child transform
        }
        rightPage = 0;
    }

    // Update is called once per frame
    void Update(){  
        // if(currentTransform != null) {
     //         currentTransform.eulerAngles = Vector3.Lerp(currentTransform.eulerAngles, targetAngles, smooth * Time.deltaTime); // lerp to new angles
        // }
    }

    public void turnRightPage() {
        if(rightPage != -1) {
            pages[rightPage].GetComponent<MusicPage>().turnRight();
            //if(!isOpen) {
            // targetAngles = pages[rightPage].eulerAngles + 180f * Vector3.forward;
            // currentTransform = pages[rightPage];

            leftPage = rightPage;
            //}
            if(rightPage < pages.Count - 1) {
                rightPage++;
            } else {
                rightPage = -1;
            }
            
            //isOpen = true;
        }
        
    }

    public void turnLeftPage() {
        if(leftPage != -1) {
            pages[leftPage].GetComponent<MusicPage>().turnLeft();
            //if(!isOpen) {
            // targetAngles = pages[rightPage].eulerAngles + 180f * Vector3.forward;
            // currentTransform = pages[rightPage];
            rightPage = leftPage;
            //}
            if(leftPage > 0) {
                leftPage--;
            } else {
                leftPage = -1;
            }
            
            //isOpen = true;
        }
        // if(!isOpen) {
        //  targetAngles = transform.eulerAngles + 180f * Vector3.forward;
        // }
        // isOpen = true;
        // start = DateTime.Now;
        // rotation = new Vector3(0,0,180);
    }

}
