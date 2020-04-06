using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Initializer : MonoBehaviour
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
}
