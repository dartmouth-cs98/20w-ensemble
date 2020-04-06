using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectActivator : MonoBehaviour
{
    public GameObject[] toActivate;
    // IEnumerator Start()
    // {
    //     for (int i = 0; i < toActivate.Length; i++)
    //     {
    //         toActivate[i].SetActive(true);
    //         yield return new WaitForSeconds(0);
    //     }
    // }
    void Start()
    {
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].SetActive(true);
        }
    }

    // void objectActivate()
    // {
    //     for (int i = 0; i < toActivate.Length; i++)
    //     {
    //         toActivate[i].SetActive(true);
    //     }
    // }
}
