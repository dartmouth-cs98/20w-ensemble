using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TempoChange : MonoBehaviour
{
    public AudioMixer master;
    public string tempo = "Tempo";
    public string pitch = "PitchOffset";
    private static float MAX = 2.0f;
    private static float MIN = .75f;

    public void SetTempo(float change) {
      if(change > MAX)
      {
        change = MAX;
      } else if(change < MIN)
      {
        change = MIN;
      }
      master.SetFloat(tempo, change);
      master.SetFloat(pitch, 1/change);
    }
}
