using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovementPingPong : MonoBehaviour
{
    private float speed = .1f;
    private float min = 0f;
    private float max = 0f;
    private bool startmoving = false;

    void Start()
    {
      min = transform.position.y;
      max = transform.position.y + .5f;
    }

    public void Initiate(float change)
    {
      startmoving = true;
      max = transform.position.y + change;
    }
    void Update()
    {
      if(startmoving)
      {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*speed, max-min), transform.position.z);
      }
    }
}
