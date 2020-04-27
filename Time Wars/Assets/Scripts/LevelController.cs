using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel = null;
    [SerializeField] GameObject loseLabel = null;
    [SerializeField] Canvas[] optionsPanel = null;
    [SerializeField] AudioSource Sound1 = null;
    [SerializeField] AudioSource Sound2 = null;
    string levelName = "";
    string heroTag = "Hero Button";
    int index = 0;

    void Awake()
    {

        levelName = SceneManager.GetActiveScene().name;

        LevelCheck();
    }

    void Start()
    {
        if (!winLabel) { return; }
        if (!loseLabel) { return; }
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    void Update()
    {
        EffectOnOrClose();
        if (PlayerPrefsController.GetLevelRepeated() == 0)
        {
            OptionsControllerDetails();
        }
    }
    public void EffectOnOrClose()
    {
        gameObject.GetComponents<AudioSource>()[0].volume = PlayerPrefsController.GetMasterEffectInt();
        gameObject.GetComponents<AudioSource>()[1].volume = PlayerPrefsController.GetMasterEffectInt();
    }
    public void OptionsControllerDetails()
    {
        if (index < optionsPanel.Length)
        {
            optionsPanel[index].gameObject.SetActive(true);
        }
    }
    public void setIndex()
    {
        optionsPanel[index].gameObject.SetActive(false);
        index++;
        if (index >= optionsPanel.Length)
        {
            CloseOptionsPanel();
        }
    }
    public void CloseOptionsPanel()
    {
        PlayerPrefsController.SetLevelRepeated(true);
        foreach (Canvas panel in optionsPanel)
        {
            panel.gameObject.SetActive(false);
        }
        PassTheStarter();
    }
    public void FirstLevelsStarterPack()
    {
        StopSpawning();
        FindObjectOfType<StarDisplay>().WorkorNot(false);
        PlayerPrefsController.SetLevelRepeated(false);
    }
    public void PassTheStarter()
    {
        StartSpawning();
        FindObjectOfType<StarDisplay>().WorkorNot(true);
        PlayerPrefsController.SetLevelRepeated(true);
    }

    public void LevelCheck()
    {
        GameObject[] defenderButtons = GameObject.FindGameObjectsWithTag(heroTag);
        if (levelName == "Level 1")
        {
            FirstLevelsStarterPack();
            foreach (GameObject defender in defenderButtons)
            {
                if (defender.name == "Hero1" || defender.name == "Hero2" || defender.name == "Stone")
                {
                    defender.SetActive(true);
                }
                else
                {
                    defender.SetActive(false);
                }
            }
        }
        else if (levelName == "Level 2")
        {
            FirstLevelsStarterPack();
            foreach (GameObject defender in defenderButtons)
            {
                if (defender.name == "Hero1" || defender.name == "Hero2" || defender.name == "Hero3" || defender.name == "Stone")
                {
                    defender.SetActive(true);
                }
                else
                {
                    defender.SetActive(false);
                }
            }
        }
        else if (levelName == "Level 3")
        {
            FirstLevelsStarterPack();
            foreach (GameObject defender in defenderButtons)
            {
                if (defender.name == "Hero1" || defender.name == "Hero2" || defender.name == "Hero3" || defender.name == "Hero4" || defender.name == "Hero5" || defender.name == "Stone")
                {
                    defender.SetActive(true);
                }
                else
                {
                    defender.SetActive(false);
                }
            }
        }
        else if (levelName == "Level 4")
        {
            FirstLevelsStarterPack();
            foreach (GameObject defender in defenderButtons)
            {
                defender.SetActive(true);
            }
        }
        else if(levelName == "Level 6")
        {
            FirstLevelsStarterPack();
        }
        else
        {
            PassTheStarter();
        }
    }

    private void HandleWinCondition()
    {
        winLabel.SetActive(true);
        PlayerPrefsController.SetLevelIndex(SceneManager.GetActiveScene().buildIndex+1);

        Sound1.Play();
        Time.timeScale = 0f;
    }
    private void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Sound2.Play();
        Time.timeScale = 0f;
    }
    public void LevelSuccessed()
    {
        HandleWinCondition();
    }
    public void LevelLoosed()
    {
        HandleLoseCondition();
    }
    public void StartSpawning()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner item in spawners)
        {
            item.enabled = true;
        }
    }
    public void StopSpawning()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner item in spawners)
        {
            item.enabled = false;
        }
    }
    
}
