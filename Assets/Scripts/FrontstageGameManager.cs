using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class FrontstageGameManager : MonoBehaviour
{
    public AccompanimentPlayer AP;
    public TempoChange TC;
    public TMP_Text tempoDisp;
    float initTempo = 0f;
    float tempo = 0f;
    float maxTempo = 0f;
    float minTempo = 0f;
    GameManager statVar;
    public AudioSource staticAudio;
    public AudioClip[] samples;
    public GameObject sceneDivider;
    public GameObject tempoMeter;
    bool showMeter = false;
    public GameObject meterButton;

    private Dictionary<string, int> songIndex = new Dictionary<string, int>()
    {
      {"canonInD", 0},
      {"letItGo", 1},
      {"beethoven5", 2}
    };
    private Dictionary<int, string> songMap = new Dictionary<int, string>()
    {
      {0, "canonInD"},
      {1, "letItGo"},
      {2, "beethoven5"}
    };
    private Dictionary<int, string> instrumentMap = new Dictionary<int, string>()
    {
      {0, "violin"},
      {1, "viola"},
      {2, "cello"},
      {3, "bass"}
    };
    // Start is called before the first frame update
    void Start()
    {
        statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
        if(String.Compare(statVar.GetStage(), "large") == 0)
        {
          sceneDivider.SetActive(false);
        } else if(String.Compare(statVar.GetStage(), "small") == 0)
        {
          sceneDivider.SetActive(true);
        }
        if(String.Compare(statVar.GetFollowing(), "static") == 0)
        {
          if(String.Compare(songMap[statVar.GetSong()], "canonInD") == 0)
          {
            ChangeInstrument("canonInD");
            initTempo = 60f;
            tempo = 60f;
            maxTempo = 120f;
            minTempo = 45f;
          } else if(String.Compare(songMap[statVar.GetSong()], "letItGo") == 0)
          {
            ChangeInstrument("letItGo");
            initTempo = 60f;
            tempo = 60f;
            maxTempo = 120f;
            minTempo = 45f;
          } else if(String.Compare(songMap[statVar.GetSong()], "beethoven5") == 0)
          {
            ChangeInstrument("beethoven5");
            initTempo = 108f;
            tempo = 108f;
            maxTempo = 216f;
            minTempo = 81f;
          }
          meterButton.SetActive(true);
        } else if(String.Compare(statVar.GetFollowing(), "follow") == 0)
        {
          meterButton.SetActive(false);
        }
    }
    void Update()
    {
        tempoDisp.text = tempo.ToString();
    }

    public void ChangeInstrument(string song)
    {
      staticAudio.clip = samples[songIndex[song]];
    }

    public void IncreaseTempo()
    {
      if(tempo < maxTempo)
      {
        tempo += 1;
        TC.SetTempo(tempo, initTempo);
      }
    }
    public void DecreaseTempo()
    {
      if(tempo > minTempo)
      {
        tempo -= 1;
        TC.SetTempo(tempo, initTempo);
      }
    }
    public void SettingsToggle()
    {
      statVar.LoadSettingsToggle();
      statVar.FrontStageToggle();
    }

    public void MeterToggle()
    {
      tempoMeter.SetActive(!showMeter);
      showMeter = !showMeter;
    }
}
