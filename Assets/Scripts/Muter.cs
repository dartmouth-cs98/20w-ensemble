using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public struct MuteManager
{
    public bool isMute;

}

public class Muter : MonoBehaviour
{
    MuteManager muteManager;
    // Update is called once per frame

    public void mutedPlay(AudioSource audio)
    {
        audio.Play();
        audio.mute = true;
    }

    public void muteUnmute(AudioSource audio)
    {
        audio.mute = !audio.mute;
        muteManager.isMute = audio.mute;
    }

    public void muteColor(GameObject sphere)
    {
        var sphereRenderer = sphere.GetComponent<Renderer>();

        if (muteManager.isMute)
        {
            sphereRenderer.material.SetColor("_Color", Color.red);
        }
        else
        {
            sphereRenderer.material.SetColor("_Color", Color.green);
        }
    }
}
