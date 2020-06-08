using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{

    [SerializeField]
    private Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime, Space.World);
    }

}