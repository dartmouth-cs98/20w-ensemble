using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    string ip;
    public TMP_Text keypadText;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
      gm = UnityEngine.Object.FindObjectOfType<GameManager>();
      keypadText.text = gm.GetIP();
      ip = gm.GetIP();
    }

    // Update is called once per frame
    void Update()
    {
      keypadText.text = gm.GetIP();
    }
    public void ConcatenateIP(string addend)
    {
      ip += addend;
      gm.ChangeIP(ip);
    }
    public void BackSpace()
    {
      ip = ip.Substring(0, ip.Length - 1);
      gm.ChangeIP(ip);
    }
}
