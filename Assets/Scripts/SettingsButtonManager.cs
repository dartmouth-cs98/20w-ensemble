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
    public GameObject score;
    public GameObject tempo;
    public GameObject none;

    void Start()
    {
      statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
      if(String.Compare(statVar.GetFollowing(), "score") == 0)
      {
        score.SetActive(true);
        tempo.SetActive(false);
        none.SetActive(false);
      } else if(String.Compare(statVar.GetFollowing(), "tempo") == 0)
      {
        score.SetActive(false);
        tempo.SetActive(true);
        none.SetActive(false);
      } else if(String.Compare(statVar.GetFollowing(), "static") == 0)
      {
        score.SetActive(false);
        tempo.SetActive(false);
        none.SetActive(true);
      }
    }
    public void Update()
    {
      numOrchestra.text = statVar.GetOrchestra().ToString();
      numAudience.text = statVar.GetAudience().ToString();
      
      if(String.Compare(statVar.GetFollowing(), "score") == 0)
      {
        score.SetActive(true);
        tempo.SetActive(false);
        none.SetActive(false);
      } else if(String.Compare(statVar.GetFollowing(), "tempo") == 0)
      {
        score.SetActive(false);
        tempo.SetActive(true);
        none.SetActive(false);
      } else if(String.Compare(statVar.GetFollowing(), "static") == 0)
      {
        score.SetActive(false);
        tempo.SetActive(false);
        none.SetActive(true);
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
    public void SelectTempo()
    {
      statVar.FollowingOptionTempo();
    }
    public void SelectNone()
    {
      statVar.FollowingOptionNone();
    }
}
