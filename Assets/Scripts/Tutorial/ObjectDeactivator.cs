using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectDeactivator : MonoBehaviour
{
    // public GameObject[] toDeactivate;

    // void Start()
    // {
    //     for (int i = 0; i < toActivate.Length; i++)
    //     {
    //         toActivate[i].SetActive(false);
    //     }
    // }

    public void deactivateObject(GameObject toDeactivate)
    {
        toDeactivate.SetActive(false);
    }

}
