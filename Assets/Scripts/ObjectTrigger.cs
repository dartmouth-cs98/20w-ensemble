using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectTrigger : MonoBehaviour
{
    public GameObject[] UITexts;

    IEnumerator Start()
    {
        for (int i = 0; i < UITexts.Length; i++)
        {
            UITexts[i].SetActive(true);
            yield return new WaitForSeconds(5);
            if (i != UITexts.Length - 1)
            {
                UITexts[i].SetActive(false);
            }
        }
    }

    public void objectActivate(List<string> myList)
    {
        // for (int i = 0; i < toActivate.Legth; i++)
        // {
        //     toActivate[i].SetActive(true);
        // }
    }

    public void objectDeactivate(GameObject toDeactivate)
    {
        toDeactivate.SetActive(false);
    }
}
