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

    public Dropdown dropdown;
    private Dictionary<int, string> AllChords = new Dictionary<int, string>()
    {
      {0, "CMaj"},
      {1, "Cmin"},
      {2, "CMM7"},
      {3, "Cmm7"},
      {4, "C7"}
    };

    public const float Root = 261.63f;
    public const float C = 261.63f;
    public const float CSharp = 277.18f;
    public const float D = 293.66f;
    public const float DSharp = 311.13f;
    public const float E = 329.63f;
    public const float F = 349.23f;
    public const float FSharp = 369.99f;
    public const float G = 392f;
    public const float GSharp = 415.3f;
    public const float A = 440f;
    public const float ASharp = 466.16f;
    public const float B = 493.88f;
    //public string chord;
    //public List<string> progression = new List<string>();
/*
    public string ConstructChord(string key, string acc, string chord, string chordSev, string sev)
    {
      string completedChord = "";
      completedChord += key + acc + chord + chordSev + sev;
      return completedChord;
    }
    void AddProgression(string chord)
    {
      progression.Add(chord);
    }*/
    void Start()
    {
      Loop(10, 60, 4, 4);
    }
    //For diff tones, use ratio of frequencies (desired/current) as the input for the pitch shifter
    void Loop(int measures, int tempo, int sigNum, int sigDen)
    {
      for(int i = 0; i < measures; i++)
      {
        bool seventhChord = false;
        float target = 0f;
        float ratio = 0f;
        float third = 0f;
        float fifth = 0f;
        float seventh = 0f;
        if(AllChords[dropdown.value] == "CMaj"){
          float freq = C;
          target = C;
          ratio = target/freq;
          third = E/freq;
          fifth = G/freq;
        } else if(AllChords[dropdown.value] == "Cmin"){
          float freq = C;
          target = C;
          ratio = target/freq;
          third = DSharp/freq;
          fifth = G/freq;
        } else if(AllChords[dropdown.value] == "CMM7"){
          float freq = C;
          target = C;
          ratio = target/freq;
          third = E/freq;
          fifth = G/freq;
          seventhChord = true;
          seventh = B/freq;
        } else if(AllChords[dropdown.value] == "Cmm7") {
          float freq = C;
          target = C;
          ratio = target/freq;
          third = DSharp/freq;
          fifth = G/freq;
          seventhChord = true;
          seventh = ASharp/freq;
        } else if(AllChords[dropdown.value] == "C7") {
          float freq = C;
          target = C;
          ratio = target/freq;
          third = E/freq;
          fifth = G/freq;
          seventhChord = true;
          seventh = ASharp/freq;
        }
        pianoRoot.SetFloat(pitch, ratio);
        pianoThird.SetFloat(pitch, third);
        pianoFifth.SetFloat(pitch, fifth);
        if(seventhChord){
          pianoSeventh.SetFloat(pitch, seventh);
          pianoS.Play();
        }
        pianoR.Play();
        pianoT.Play();
        pianoF.Play();
        StartCoroutine(Wait(tempo));
        
      }
    }
    IEnumerator Wait(int tempo)
    {
        float seconds = 60/tempo;
        yield return new WaitForSeconds(seconds);
    }
}
