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

    public void SetTempo(float change, float start) {
      float val = change/start;
      if(val > MAX)
      {
        val = MAX;
      } else if(val < MIN)
      {
        val = MIN;
      }
      master.SetFloat(tempo, val);
      master.SetFloat(pitch, 1/val);
    }
}
