using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOscillator : MonoBehaviour
{
    // private float speed = .075f;
    public float speed;
    private float min = 0f;
    private float displacement = 0f;
    private bool startmoving = false;
    public float change;

    public void Start()
    {
        startmoving = true;
        min = transform.position.y;
        displacement = change;
    }

    void Update()
    {
        if (startmoving)
        {
            transform.position = new Vector3(transform.position.x, min + Mathf.PingPong(Time.time * speed, displacement), transform.position.z);
        }
    }
}
