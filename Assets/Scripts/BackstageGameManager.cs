using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackstageGameManager : MonoBehaviour
{
    GameManager statVar;
    // Start is called before the first frame update
    void Start()
    {
      statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
    }
    public void SettingsToggle()
    {
      statVar.LoadSettingsToggle();
      statVar.BackStageToggle();
    }
}
