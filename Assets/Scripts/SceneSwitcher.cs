using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void moveForward()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void moveBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void moveBackTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void moveForwardTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void goToFrontStage()
    {
        SceneManager.LoadScene("Frontstage");
    }

    public void toStartScreen()
    {
      SceneManager.LoadScene("StartScreen");
    }

    public void toBackStage()
    {
      SceneManager.LoadScene("Backstage1");
    }

    public void restartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
