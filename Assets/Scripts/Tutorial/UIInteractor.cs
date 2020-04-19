using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractor : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (uiObject.gameObject.transform.localScale.x > 15)
        {
            uiObject.gameObject.transform.localScale -= new Vector3(+0.1f, 0, +0.1f);
        }
        else if (uiObject.gameObject.transform.localScale.x < 8)
        {
            uiObject.gameObject.transform.localScale += new Vector3(+0.1f, 0, +0.1f);

        }
    }
}
