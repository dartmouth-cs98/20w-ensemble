using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookFlipper : MonoBehaviour
{
    //public GameObject page;
    public List<GameObject> pages;
    private bool isMoving = false;
    private bool right = false;
    private int currentPage = 0;
    private float initialFlip;
    private float flippedAmount = 174;
    void Update()
    {
        //right flip
        if (isMoving && right)
        {
            pages[currentPage].transform.Rotate(0, 0, 125 * Time.deltaTime, Space.Self);
            flippedAmount = pages[currentPage].transform.eulerAngles.z - initialFlip;
            if (flippedAmount >= 174)
            {
                isMoving = false;
                right = false;
                currentPage = currentPage + 1;
            }
        }
        //left flip
        else if (isMoving && (right == false))
        {
            pages[currentPage].transform.Rotate(0, 0, -125 * Time.deltaTime, Space.Self);
            flippedAmount = initialFlip - pages[currentPage].transform.eulerAngles.z;
            if (flippedAmount >= 174)
            {
                right = true;
                isMoving = false;
            }
        }
    }


    public void rightFlip()
    {
        if ((currentPage < pages.Count) && (flippedAmount >= 174))
        {
            initialFlip = pages[currentPage].transform.eulerAngles.z;
            isMoving = true;
            right = true;
        }
    }

    public void leftFlip()
    {
        if ((0 < currentPage) && (flippedAmount >= 174))
        {
            isMoving = true;
            right = false;
            currentPage = currentPage - 1;
            initialFlip = pages[currentPage].transform.eulerAngles.z;
        }
    }
}
