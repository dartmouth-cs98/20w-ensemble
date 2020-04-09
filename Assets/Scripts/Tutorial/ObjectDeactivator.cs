using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectDeactivator : MonoBehaviour
{
    public void deactivateObject(GameObject toDeactivate)
    {
        toDeactivate.SetActive(false);
    }
}
