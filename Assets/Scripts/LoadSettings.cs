using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSettings : MonoBehaviour
{
    public GameObject startObjs;

    public void AddSettings()
    {
      SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    }
    public void HideStartScreen()
    {
      startObjs.SetActive(false);
    }
}
