using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    int currentSceneIndex;
    int timeToWait = 4;
    int savedSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
        //PlayerPrefsController.SetLevelIndex(0);
        savedSceneIndex = PlayerPrefsController.GetLevelIndex();
        if (savedSceneIndex == 0)
        {
            if (GameObject.Find("Continue Text"))
                GameObject.Find("Continue Text").GetComponent<Button>().interactable = false;
        }
        else
        {
            if (GameObject.Find("Continue Text"))
                GameObject.Find("Continue Text").GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }
    public void LoadStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadFinished()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lose Screen");
    }
    public void LoadSavedScene()
    {
        if (savedSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(savedSceneIndex - 1);
        }
        else
        {
            SceneManager.LoadScene(savedSceneIndex);
        }
    }
    public void LoadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextScene()
    {
        Time.timeScale = 1;
        if (SceneManager.sceneCountInBuildSettings == (SceneManager.GetActiveScene().buildIndex + 1))
        {
            LoadFinished();
        }
        else
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void NewGameScene()
    {
        Time.timeScale = 1;
        PlayerPrefsController.SetLevelRepeated(false);
        SceneManager.LoadScene("Level 1");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

}
