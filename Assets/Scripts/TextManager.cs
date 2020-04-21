using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameObject[] texts;

    public void FadeInAudience()
    {
      texts[0].SetActive(true);
    }
    public void FadeInOrchestra()
    {
      texts[1].SetActive(true);
    }
    public void FadeInFollowing()
    {
      texts[2].SetActive(true);
    }
    public void FadeInScore()
    {
      texts[3].SetActive(true);
    }
    public void FadeInTempo()
    {
      texts[4].SetActive(true);
    }
    public void FadeInStatic()
    {
      texts[5].SetActive(true);
    }
    public void FadeOutAudience()
    {
      texts[0].SetActive(false);
    }
    public void FadeOutOrchestra()
    {
      texts[1].SetActive(false);
    }
    public void FadeOutFollowing()
    {
      texts[2].SetActive(false);
    }
    public void FadeOutScore()
    {
      texts[3].SetActive(false);
    }
    public void FadeOutTempo()
    {
      texts[4].SetActive(false);
    }
    public void FadeOutStatic()
    {
      texts[5].SetActive(false);
    }
}
