using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonManager : MonoBehaviour
{
    public GameManager statVar = GameObject.Find("GameManager");
    public GameObject score;
    public GameObject tempo;
    public GameObject none;
    public GameObject numAudience;
    public GameObject numOrchestra;
    public Material[] numbers;

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
    public void Update()
    {
      numOrchestra.GetComponent<Renderer>().material = numbers[statVar.getOrchestra()];
      numAudience.GetComponent<Renderer>().material = numbers[statVar.getAudience()];
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
    public void OrchestraUp()
    {
      statVar.orchestraOptionUp();
    }
    public void OrchestraDown()
    {
      statVar.orchestraOptionDown();
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
      statVar.followingOptionScore();
    }
    public void SelectTempo()
    {
      statVar.followingOptionTempo();
    }
    public void SelectNone()
    {
      statVar.followingOptionNone();
    }
}
