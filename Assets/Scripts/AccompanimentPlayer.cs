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
      {"cello", 1}
    };

    public void NoteOn(int midi, float duration, string instrument)
    {
      noteplayers[instrumentMap[instrument]].NoteOn(midi);
    }

    public void NoteOff(string instrument)
    {
      noteplayers[instrumentMap[instrument]].NoteOff();
    }
}
