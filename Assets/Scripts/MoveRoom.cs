using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
	GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
    	gm = UnityEngine.Object.FindObjectOfType<GameManager>();
    	this.transform.position = gm.currPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = gm.currPosition;
    }
}
