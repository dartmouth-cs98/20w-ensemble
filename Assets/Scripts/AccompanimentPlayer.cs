using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AccompanimentPlayer : MonoBehaviour
{
    public NotePlayer[] noteplayers;

    private Dictionary<string, int> instrumentMap = new Dictionary<string, int>()
    {
      {"violin", 0},
      {"cello", 1},
      {"viola", 2},
      {"bass", 3}
    };

    public void PlayNote(int midi, float duration, string instrument)
    {
      noteplayers[instrumentMap[instrument]].NoteOn(midi);
    }
    public void StopNote(string instrument)
    {
      noteplayers[instrumentMap[instrument]].NoteOff();
    }
}
