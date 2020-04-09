using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectActivator : MonoBehaviour
{
    public void activateObject(GameObject toActivate)
    {
        toActivate.SetActive(true);
    }
}
