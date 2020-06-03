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
    public void FadeOutScore()
    {
      texts[0].SetActive(false);
    }
    public void FadeOutStatic()
    {
      texts[1].SetActive(false);
    }
}
