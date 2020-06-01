using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NotePlayer : MonoBehaviour
{
    public AudioSource instrument;
    public AudioMixer mixer;
    public AudioClip[] clips = new AudioClip[5];
    private int previousMidi = -2;
    public string pitch = "PitchOffset";

    private Dictionary<int, float> midiToFrequency = new Dictionary<int, float>()
    {
      {0, 8.18f},
      {1, 8.66f},
      {2, 9.18f},
      {3, 9.72f},
      {4, 10.30f},
      {5, 10.91f},
      {6, 11.56f},
      {7, 12.25f},
      {8, 12.98f},
      {9, 13.75f},
      {10, 14.57f},
      {11, 15.43f},
      {12, 16.35f},
      {13, 17.32f},
      {14, 18.35f},
      {15, 19.45f},
      {16, 20.60f},
      {17, 21.83f},
      {18, 23.12f},
      {19, 24.50f},
      {20, 25.96f},
      {21, 27.50f},
      {22, 29.14f},
      {23, 30.87f},
      {24, 32.70f},
      {25, 34.65f},
      {26, 36.71f},
      {27, 38.89f},
      {28, 41.20f},
      {29, 43.65f},
      {30, 46.25f},
      {31, 49.00f},
      {32, 51.91f},
      {33, 55.00f},
      {34, 58.27f},
      {35, 61.74f},
      {36, 65.41f},
      {37, 69.30f},
      {38, 73.42f},
      {39, 77.78f},
      {40, 82.41f},
      {41, 87.31f},
      {42, 92.50f},
      {43, 98.00f},
      {44, 103.83f},
      {45, 110.00f},
      {46, 116.54f},
      {47, 123.47f},
      {48, 130.81f},
      {49, 138.59f},
      {50, 146.83f},
      {51, 155.56f},
      {52, 164.81f},
      {53, 174.61f},
      {54, 185.00f},
      {55, 196.00f},
      {56, 207.65f},
      {57, 220.00f},
      {58, 233.08f},
      {59, 246.94f},
      {60, 261.63f},
      {61, 277.18f},
      {62, 293.66f},
      {63, 311.13f},
      {64, 329.63f},
      {65, 349.23f},
      {66, 369.99f},
      {67, 392.00f},
      {68, 440.00f},
      {70, 466.16f},
      {71, 493.88f},
      {72, 523.25f},
      {73, 554.37f},
      {74, 587.33f},
      {75, 622.25f},
      {76, 659.26f},
      {77, 698.46f},
      {78, 739.99f},
      {79, 783.99f},
      {80, 830.61f},
      {81, 880.00f},
      {82, 932.33f},
      {83, 987.77f},
      {84, 1046.50f},
      {85, 1108.73f},
      {86, 1174.66f},
      {87, 1244.51f},
      {88, 1318.51f},
      {89, 1396.91f},
      {90, 1479.98f},
      {91, 1567.98f},
      {92, 1661.22f},
      {93, 1760.00f},
      {94, 1864.66f},
      {95, 1975.53f},
      {96, 2093.00f},
      {97, 2217.46f},
      {98, 2349.32f},
      {99, 2489.02f},
      {100, 2637.00f},
      {101, 2793.83f},
      {102, 2959.96f},
      {103, 3135.96f},
      {104, 3322.44f},
      {105, 3520.00f},
      {106, 3729.31f},
      {107, 3951.07f},
      {108, 4186.01f},
      {109, 4434.92f},
      {110, 4698.64f},
      {111, 4978.03f},
      {112, 5274.04f},
      {113, 5587.65f},
      {114, 5919.91f},
      {115, 6271.93f},
      {116, 6644.88f},
      {117, 7040.00f},
      {118, 7458.62f},
      {119, 7902.13f},
      {120, 8372.02f},
      {121, 8869.84f},
      {122, 9397.27f},
      {123, 9956.06f},
      {124, 10548.08f},
      {125, 11175.30f},
      {126, 11839.82f},
      {127, 12543.85f},
      {128, 13289.75f}
    };
    // store values in hash to cut down on time to play notes
    private Dictionary<int, int> clipMap = new Dictionary<int, int>()
    {
      {36, 0},
      {37, 0},
      {38, 0},
      {39, 0},
      {40, 0},
      {41, 0},
      {42, 0},
      {43, 0},
      {44, 0},
      {45, 0},
      {46, 0},
      {47, 0},
      {48, 1},
      {49, 1},
      {50, 1},
      {51, 1},
      {52, 1},
      {53, 1},
      {54, 1},
      {55, 1},
      {56, 1},
      {57, 1},
      {58, 1},
      {59, 1},
      {60, 2},
      {61, 2},
      {62, 2},
      {63, 2},
      {64, 2},
      {65, 2},
      {66, 2},
      {67, 2},
      {68, 2},
      {69, 2},
      {70, 2},
      {71, 2},
      {72, 3},
      {73, 3},
      {74, 3},
      {75, 3},
      {76, 3},
      {77, 3},
      {78, 3},
      {79, 3},
      {80, 3},
      {81, 3},
      {82, 3},
      {83, 3},
      {84, 4},
      {85, 4},
      {86, 4},
      {87, 4},
      {88, 4},
      {89, 4},
      {90, 4},
      {91, 4},
      {92, 4},
      {93, 4},
      {94, 4},
      {95, 4}
    };

    public void NoteOn(int midi)
    {
      if(!instrument.isPlaying || (midi != previousMidi && instrument.isPlaying)){
        Debug.Log("playingnote");
        //processing = true;
        float ratio = 1f;
        instrument.clip = FindCloseRoot(midi);
        string name = instrument.clip.name;
        string rootValue = name.Substring(name.Length - 3);
        int rootVal = 0;
        if(Int32.TryParse(rootValue, out rootVal))
        {
          ratio = midiToFrequency[midi]/midiToFrequency[rootVal];
        }
        mixer.SetFloat(pitch, ratio);
        instrument.Play();
      }
    }

    private AudioClip FindCloseRoot(int midi)
    {
      // original approach for scalability: too costly per frame
      /*AudioClip closeClip = clips[0];
      foreach(AudioClip clip in clips)
      {
        string rootValue = clip.name.Substring(clip.name.Length - 3);
        int rootVal = 0;
        if(Int32.TryParse(rootValue, out rootVal))
        {
          if(midi >= rootVal)
          {
            closeClip = clip;
          }
        }
      }
      previousMidi = midi;
      return closeClip;*/
      previousMidi = midi;
      string rootValue = clips[0].name.Substring(clips[0].name.Length - 3);
      int rootVal = 0;
      if(Int32.TryParse(rootValue, out rootVal))
      {
        if(rootVal == 55)
        {
          return clips[clipMap[midi - 19]];
        }
        return clips[clipMap[midi]];
      } else return null;
    }

    public void NoteOff()
    {
    //  processing = false;
      if(instrument.isPlaying){
        instrument.Stop();
      }
      previousMidi = -1;
    }
}
