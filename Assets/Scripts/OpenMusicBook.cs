using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class OpenMusicBook : MonoBehaviour
{ 
    public TextMeshPro chalkboardText;
    List<GameObject> pages;
    int leftPage = -1;
    int rightPage = -1;

    // Start is called before the first frame update
    void Start()
    {
        pages = new List<GameObject>();
        foreach (Transform child in transform){
            pages.Add(child.gameObject);
        }

        rightPage = 0;
    }

    // Update is called once per frame
    void Update(){  
    }

    public void turnRightPage() {
        if(rightPage != -1) {
            pages[rightPage].GetComponent<MusicPage>().turnRight();

            leftPage = rightPage;
            chalkboardText.text = pages[leftPage].GetComponent<MusicPage>().pageName;
            if(rightPage < pages.Count) {
                rightPage++;
            } else {
                rightPage = -1;
            }
        }
    }

    public void turnLeftPage() {
        if(leftPage != -1) {
            pages[leftPage].GetComponent<MusicPage>().turnLeft();

            rightPage = leftPage;
            if(leftPage > 0) {
                leftPage--;
                chalkboardText.text = pages[leftPage].GetComponent<MusicPage>().pageName;
            } else {
                leftPage = -1;
                chalkboardText.text = "No music selected!";
            }

        }
    }

}
