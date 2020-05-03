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

    GameManager gm;
    GameObject gmObject;
    // Start is called before the first frame update
    void Start()
    {
        //gmObject = GameObject.Find("GameManager");
        //gm = gmObject.GetComponent<GameManager>();
        gm = UnityEngine.Object.FindObjectOfType<GameManager>();
        pages = new List<GameObject>();
        foreach (Transform child in transform)
        {
            pages.Add(child.gameObject);
        }

        rightPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void turnRightPage()
    {
        if (rightPage != -1)
        {
            pages[rightPage].GetComponent<MusicPage>().turnRight();

            leftPage = rightPage;
            // chalkboardText.text = "Selected Song:\n" + pages[leftPage].GetComponent<MusicPage>().pageName;
            gm.songID = leftPage;
            if (rightPage < pages.Count - 1)
            {
                rightPage++;
            }
            else
            {
                rightPage = -1;
            }
        }
    }

    public void turnLeftPage()
    {
        //chalkboardText.text = "No music selected.";
        if (leftPage != -1)
        {
            pages[leftPage].GetComponent<MusicPage>().turnLeft();

            rightPage = leftPage;
            if (leftPage > 0)
            {
                leftPage--;
                // chalkboardText.text = "Selected Song:\n" + pages[leftPage].GetComponent<MusicPage>().pageName;
                gm.songID = leftPage;
            }
            else
            {
                leftPage = -1;
                gm.songID = -1;
                // chalkboardText.text = "No music selected.";
            }

        }
    }

}
