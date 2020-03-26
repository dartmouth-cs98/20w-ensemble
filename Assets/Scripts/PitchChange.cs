using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchChange : MonoBehaviour
{
    public AudioMixer master;
    public string pitch = "PitchOffset";

    public void SetPitch(float change) {
      master.SetFloat(pitch, change);
    }
}
