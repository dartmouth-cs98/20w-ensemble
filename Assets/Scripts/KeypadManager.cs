using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public string ip;
    public GameObject pad;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        if(gm.KeypadReveal())
        {
          pad.SetActive(true);
        }
        else
        {
          pad.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(gm.KeypadReveal())
      {
        pad.SetActive(true);
      }
      else
      {
        pad.SetActive(false);
      }
    }
    public void ConcatenateIP(string addend)
    {
      ip += addend;
    }
    public void BackSpace()
    {
      ip = ip.Substring(0, ip.Length - 1);
    }
    public void ChangeIP()
    {
      gm.ChangeIP(ip);
    }
}
