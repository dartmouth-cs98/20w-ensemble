﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonManager : MonoBehaviour
{
    public StaticVariables statVar;
    public GameObject score;
    public GameObject tempo;
    public GameObject none;

    public void Start()
    {
      if(String.Compare(statVar.getFollowing(), "score") == 0)
      {
        score.SetActive(true);
        tempo.SetActive(false);
        none.SetActive(false);
      } else if(String.Compare(statVar.getFollowing(), "tempo") == 0)
      {
        score.SetActive(false);
        tempo.SetActive(true);
        none.SetActive(false);
      } else if(String.Compare(statVar.getFollowing(), "static") == 0)
      {
        score.SetActive(false);
        tempo.SetActive(false);
        none.SetActive(true);
      }
    }
    public void SelectScore()
    {
      score.SetActive(true);
      tempo.SetActive(false);
      none.SetActive(false);
    }
    public void SelectTempo()
    {
      score.SetActive(false);
      tempo.SetActive(true);
      none.SetActive(false);
    }
    public void SelectStatic()
    {
      score.SetActive(false);
      tempo.SetActive(false);
      none.SetActive(true);
    }

}
