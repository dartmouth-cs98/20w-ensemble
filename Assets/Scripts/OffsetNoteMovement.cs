using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetNoteMovement : MonoBehaviour
{
    public VerticalMovementPingPong[] paths;
    private bool alternate = true;

    void Start()
    {
      foreach(VerticalMovementPingPong path in paths)
      {
        if(alternate)
        {
          alternate = false;
          path.Initiate(Random.Range(0.1f, 0.3f));
        } else
        {
          alternate = true;
          path.Initiate(Random.Range(-0.3f, -0.1f));
        }
      }
    }
}
