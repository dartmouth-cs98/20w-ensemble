using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChordProgression : MonoBehaviour
{
    public AudioSource pianoR;
    public AudioSource pianoT;
    public AudioSource pianoF;
    public AudioSource pianoS;
    public AudioSource bass;
    public AudioMixer pianoRoot;
    public AudioMixer pianoThird;
    public AudioMixer pianoFifth;
    public AudioMixer pianoSeventh;
    public AudioMixer bassline;
    public string pitch = "PitchOffset";
    public Slider tempo;
    public int sigNum;
    public int sigDen;
    public int measures;

    public Dropdown[] keys;
    public Dropdown[] accidentals;
    public Dropdown[] qualities;
    private Dictionary<int, string> notes = new Dictionary<int, string>()
    {
      {0, "C"},
      {1, "D"},
      {2, "E"},
      {3, "F"},
      {4, "G"},
      {5, "A"},
      {6, "B"}
    };
    private Dictionary<int, string> accs = new Dictionary<int, string>()
    {
      {0, "Natural"},
      {1, "Sharp"},
      {2, "Flat"}
    };
    private Dictionary<int, string> chordQualities = new Dictionary<int, string>()
    {
      {0, "Maj"},
      {1, "min"},
      {2, "MM7"},
      {3, "mm7"},
      {4, "7"},
      {5, "dim7"},
      {6, "halfDim7"}
    };
    public const float Root = 261.63f;
    private Dictionary<string, float> noteFreq = new Dictionary<string, float>()
    {
      {"C", 261.63f},
      {"CSharp", 277.18f},
      {"D", 293.66f},
      {"DSharp", 311.13f},
      {"E", 329.63f},
      {"F", 349.23f},
      {"FSharp", 369.99f},
      {"G", 392f},
      {"GSharp", 415.3f},
      {"A", 440f},
      {"ASharp", 466.16f},
      {"B", 493.88f}
    };
    private Dictionary<int, string> noteMap = new Dictionary<int, string>()
    {
      {0, "C"},
      {1, "CSharp"},
      {2, "D"},
      {3, "DSharp"},
      {4, "E"},
      {5, "F"},
      {6, "FSharp"},
      {7, "G"},
      {8, "GSharp"},
      {9, "A"},
      {10, "ASharp"},
      {11, "B"},
    };

    //For diff tones, use ratio of frequencies (desired/current) as the input for the pitch shifter
    public void Play()
    {
      float freq = Root;
      float target = 0f;
      float ratio = 0f;
      float third = 0f;
      float fifth = 0f;
      float seventh = 0f;
      int map = 0;
      int j = 0;
      if(notes[keys[j].value] + accs[accidentals[j].value] == "CNatural" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "BSharp")
      {
        target = noteFreq["C"]/freq;
        map = 0;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "CSharp" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "DFlat")
      {
        target = noteFreq["CSharp"]/freq;
        map = 1;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "DNatural")
      {
        target = noteFreq["D"]/freq;
        map = 2;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "DSharp" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "EFlat")
      {
        target = noteFreq["DSharp"]/freq;
        map = 3;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "ENatural" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "FFlat")
      {
        target = noteFreq["E"]/freq;
        map = 4;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "FNatural" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "ESharp")
      {
        target = noteFreq["F"]/freq;
        map = 5;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "FSharp" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "GFlat")
      {
        target = noteFreq["FSharp"]/freq;
        map = 6;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "GNatural")
      {
        target = noteFreq["G"]/freq;
        map = 7;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "GSharp" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "AFlat")
      {
        target = noteFreq["GSharp"]/freq;
        map = 8;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "ANatural")
      {
        target = noteFreq["A"]/freq;
        map = 9;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "ASharp" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "BFlat")
      {
        target = noteFreq["ASharp"]/freq;
        map = 10;
      }else if(notes[keys[j].value] + accs[accidentals[j].value] == "BNatural" ||
      notes[keys[j].value] + accs[accidentals[j].value] == "CFlat")
      {
        target = noteFreq["B"]/freq;
        map = 11;
      }

      if(chordQualities[qualities[j].value] == "Maj")
      {
        third = noteFreq[noteMap[(map + 4) % 12]]/freq;
        fifth = noteFreq[noteMap[(map + 7) % 12]]/freq;
        seventh = noteFreq[noteMap[map]]/freq;
      }else if(chordQualities[qualities[j].value] == "min")
      {
        third = noteFreq[noteMap[(map + 3) % 12]]/freq;
        fifth = noteFreq[noteMap[(map + 7) % 12]]/freq;
        seventh = noteFreq[noteMap[map]]/freq;
      }else if(chordQualities[qualities[j].value] == "MM7")
      {
        third = noteFreq[noteMap[(map + 4) % 12]]/freq;
        fifth = noteFreq[noteMap[(map + 7) % 12]]/freq;
        seventh = noteFreq[noteMap[(map + 11) % 12]]/freq;
      }else if(chordQualities[qualities[j].value] == "mm7")
      {
        third = noteFreq[noteMap[(map + 3) % 12]]/freq;
        fifth = noteFreq[noteMap[(map + 7) % 12]]/freq;
        seventh = noteFreq[noteMap[(map + 10) % 12]]/freq;
      }else if(chordQualities[qualities[j].value] == "7")
      {
        third = noteFreq[noteMap[(map + 4) % 12]]/freq;
        fifth = noteFreq[noteMap[(map + 7) % 12]]/freq;
        seventh = noteFreq[noteMap[(map + 10) % 12]]/freq;
      }else if(chordQualities[qualities[j].value] == "dim7")
      {
        third = noteFreq[noteMap[(map + 3) % 12]]/freq;
        fifth = noteFreq[noteMap[(map + 6) % 12]]/freq;
        seventh = noteFreq[noteMap[(map + 9) % 12]]/freq;
      }else if(chordQualities[qualities[j].value] == "halfDim7")
      {
        third = noteFreq[noteMap[(map + 3) % 12]]/freq;
        fifth = noteFreq[noteMap[(map + 6) % 12]]/freq;
        seventh = noteFreq[noteMap[(map + 10) % 12]]/freq;
      }
      pianoRoot.SetFloat(pitch, target);
      pianoThird.SetFloat(pitch, third);
      pianoFifth.SetFloat(pitch, fifth);
      pianoSeventh.SetFloat(pitch, seventh);
      StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
      pianoR.Play();
      pianoT.Play();
      pianoF.Play();
      pianoS.Play();
      float sec = 60/tempo.value * 1.0f;
      yield return new WaitForSeconds(sec);
      pianoR.Stop();
      pianoT.Stop();
      pianoF.Stop();
      pianoS.Stop();
      pianoR.Play();
    }
}
