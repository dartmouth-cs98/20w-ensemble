using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 offset;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Vector3 newPos = startPos;
        newPos.x += Mathf.Sin(Time.time * speed) * offset.x;
        newPos.y += Mathf.Sin(Time.time * speed) * offset.y;
        newPos.z += Mathf.Sin(Time.time * speed) * offset.z;
        transform.position = newPos;
    }
}