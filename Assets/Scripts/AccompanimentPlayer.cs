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
      {"bass", 2},
      {"flute", 3},
      {"trumpet", 4},
      {"viola", 5},
    };

    public void PlayNote(int midi, float duration, string instrument)
    {
      noteplayers[instrumentMap[instrument]].PlayNote(midi, duration);
    }
}
