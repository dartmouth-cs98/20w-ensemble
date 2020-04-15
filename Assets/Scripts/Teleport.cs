using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

	public GameObject room;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = UnityEngine.Object.FindObjectOfType<GameManager>();
        gm.currPosition = room.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleport() {
    	room.transform.position = room.transform.position - this.transform.position;
        gm.currPosition = room.transform.position;
    }
}
