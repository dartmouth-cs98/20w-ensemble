using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muter : MonoBehaviour
{
    // Update is called once per frame
    void muteUnmute(AudioSource audio)
    {
        audio.mute=!audio.mute;
    }
}
