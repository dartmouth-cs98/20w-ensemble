using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameObject[] texts;

    public void FadeInScore()
    {
      texts[0].SetActive(true);
    }
    public void FadeInStatic()
    {
      texts[1].SetActive(true);
    }
    public void FadeInSmall()
    {
      texts[2].SetActive(true);
    }
    public void FadeInLarge()
    {
      texts[3].SetActive(true);
    }
    public void FadeOutScore()
    {
      texts[0].SetActive(false);
    }
    public void FadeOutStatic()
    {
      texts[1].SetActive(false);
    }
    public void FadeOutSmall()
    {
      texts[2].SetActive(false);
    }
    public void FadeOutLarge()
    {
      texts[3].SetActive(false);
    }
}
