using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AccompanimentPlayer : MonoBehaviour
{
    public NotePlayer[] noteplayers;
    //private bool processing = false;

    /*private Dictionary<string, int> instrumentMap = new Dictionary<string, int>()
    {
      {"violin", 0},
      {"cello", 1},
      {"viola", 2},
      {"bass", 3}
    };*/

    public void PlayNote(int midi, int instrument)
    {
    //  if(!processing){
      //  processing = true;
        Debug.Log("playing");
        noteplayers[instrument].NoteOn(midi);
    //  }
    }
    public void StopNote(int instrument)
    {
      //if(!processing){
        //Debug.Log("stopping");
        noteplayers[instrument].NoteOff();
    //  }
    }
}
