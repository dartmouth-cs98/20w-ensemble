using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsButtonManager : MonoBehaviour
{
    GameManager statVar;
    public TMP_Text numAudience;
    public TMP_Text numOrchestra;
    public GameObject follow;
    public GameObject none;
    public GameObject small;
    public GameObject large;
    public GameObject frontStageButton;
    public GameObject keypad;
    public GameObject followingTempo;
    public TMP_Text initialTempo;

    void Start()
    {
      statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
      if(String.Compare(statVar.GetFollowing(), "follow") == 0)
      {
        follow.SetActive(true);
        none.SetActive(false);
        keypad.SetActive(true);
        followingTempo.SetActive(true);
      } else if(String.Compare(statVar.GetFollowing(), "static") == 0)
      {
        follow.SetActive(false);
        keypad.SetActive(false);
        followingTempo.SetActive(false);
        none.SetActive(true);
      }
      if(String.Compare(statVar.GetStage(), "large") == 0)
      {
        large.SetActive(true);
        small.SetActive(false);
      } else if(String.Compare(statVar.GetStage(), "small") == 0)
      {
        large.SetActive(false);
        small.SetActive(true);
      }
      frontStageButton.SetActive(statVar.FromFrontStage());
    }
    void Update()
    {
      numOrchestra.text = statVar.GetOrchestra().ToString();
      numAudience.text = statVar.GetAudience().ToString();

      if(String.Compare(statVar.GetFollowing(), "follow") == 0)
      {
        follow.SetActive(true);
        none.SetActive(false);
        keypad.SetActive(true);
        followingTempo.SetActive(true);
        initialTempo.text = statVar.GetTempo().ToString();
      } else if(String.Compare(statVar.GetFollowing(), "static") == 0)
      {
        follow.SetActive(false);
        keypad.SetActive(false);
        followingTempo.SetActive(false);
        none.SetActive(true);
      }
      if(String.Compare(statVar.GetStage(), "large") == 0)
      {
        large.SetActive(true);
        small.SetActive(false);
      } else if(String.Compare(statVar.GetStage(), "small") == 0)
      {
        large.SetActive(false);
        small.SetActive(true);
      }
    }
    public void OrchestraUp()
    {
      statVar.OrchestraOptionUp();
    }
    public void OrchestraDown()
    {
      statVar.OrchestraOptionDown();
    }
    public void AudienceUp()
    {
      statVar.AudienceOptionUp();
    }
    public void AudienceDown()
    {
      statVar.AudienceOptionDown();
    }
    public void SelectScore()
    {
      statVar.FollowingOptionScore();
    }
    public void SelectNone()
    {
      statVar.FollowingOptionNone();
    }
    public void SelectSmall()
    {
      statVar.SmallStage();
    }
    public void SelectLarge()
    {
      statVar.LargeStage();
    }
    public void ToggleFront()
    {
      statVar.FrontStageToggle();
    }
    public void TempoUp()
    {
      statVar.TempoUp();
    }
    public void TempoDown()
    {
      statVar.TempoDown();
    }
}
