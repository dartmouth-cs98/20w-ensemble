using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontstageGameManager : MonoBehaviour
{
    GameManager statVar;
    public GameObject sceneDivider;
    // Start is called before the first frame update
    void Start()
    {
        statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
        if(String.Compare(statVar.GetStage(), "large") == 0)
        {
          sceneDivider.SetActive(false);
        } else if(String.Compare(statVar.GetStage(), "small") == 0)
        {
          sceneDivider.SetActive(true);
        }
    }

    public void SettingsTrue()
    {
        statVar.ShouldLoadSettings();
    }

}
