using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] AudioSource Sound1;
    [SerializeField] AudioSource Sound2;
    //int numberOfAttackers = 0;

    void Start()
    {
        if (!winLabel) { return; }
        if (!loseLabel) { return; }
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    /*public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            
        }
    }*/
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        Sound1.Play();
        yield return new WaitForSeconds(6);
        FindObjectOfType<LevelLoader>().NewGameScene();
    }
    IEnumerator HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Sound2.Play();
        yield return new WaitForSeconds(6);
    }
    public void LevelSuccessed()
    {
        //StopSpawners();
        StartCoroutine(HandleWinCondition());
    }
    public void LevelLoosed()
    {
        //StopSpawners();
        StartCoroutine(HandleLoseCondition());
    }

    /*private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }*/
}
