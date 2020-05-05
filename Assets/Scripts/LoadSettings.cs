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

    void Start()
    {
      statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
      if(statVar.ShouldLoadSettings())
      {
        startObjs.SetActive(false);
        AddSettings();
      }
    }
    public void AddSettings()
    {
      SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
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
