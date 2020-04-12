using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateTitle : MonoBehaviour
{
    private float speed = .2f;
    private float maxRotation = 15f;

    void Update()
    {
      transform.rotation = Quaternion.Euler(transform.rotation.x, maxRotation * Mathf.Sin(Time.time * speed) - 7.5f + 180f, transform.rotation.z);
    }
}
