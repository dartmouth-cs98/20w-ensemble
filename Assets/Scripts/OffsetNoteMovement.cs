using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetNoteMovement : MonoBehaviour
{
    public VerticalMovementPingPong[] paths;
    private int curr = 0;
    private bool alternate = true;

    void Start()
    {
      foreach(VerticalMovementPingPong path in paths)
      {
        if(alternate)
        {
          alternate = !alternate;
          path.Initiate(Random.Range(0.25f, 0.5f));
        } else
        {
          alternate = !alternate;
          path.Initiate(Random.Range(-0.5f, -0.25f));
        }
      }
    }
}
