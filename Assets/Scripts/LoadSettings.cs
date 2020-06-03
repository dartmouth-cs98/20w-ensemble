using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSettings : MonoBehaviour
{
    GameManager statVar;
    public GameObject startObjs;
    public GameObject backButton;
    bool loadSettings = false;

    void Start()
    {
      statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
      if(statVar.FromFrontStage())
      {
        startObjs.SetActive(false);
        AddSettings();
      }
    }
    public void AddSettings()
    {
      if(loadSettings)
      {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
        loadSettings = !loadSettings;
      }
    }
    public void HideStartScreen()
    {
      startObjs.SetActive(false);
    }
    public void RevealStartScreen()
    {
      startObjs.SetActive(true);
    }
    public void UnloadSettings()
    {
      loadSettings = !loadSettings;
      StartCoroutine("UnloadSet");
    }
    public void RevealBackButton()
    {
      backButton.SetActive(true);
    }
    public void HideBackButton()
    {
      StartCoroutine("HideBack");
    }
    IEnumerator HideBack()
    {
      yield return null;
      backButton.SetActive(false);
    }
    IEnumerator UnloadSet()
    {
      yield return null;
      SceneManager.UnloadSceneAsync("Settings");
    }
}
