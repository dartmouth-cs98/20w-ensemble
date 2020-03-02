using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muter : MonoBehaviour
{
    // ;
    // void start(){
    //     audioSource = GetComponent<AudioSource>();
    // }
    

    // Update is called once per frame
    public void muteUnmute(AudioSource audioSource)
    {
        //audioSource = GetComponent<AudioSource>();
        audioSource.mute=!audioSource.mute;
    }
}
