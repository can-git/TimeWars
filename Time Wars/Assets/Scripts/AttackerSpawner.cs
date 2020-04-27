using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float maxSpawnDelay = 7f;
    [SerializeField] public float minSpawnDelay = 3f;
    float maxSpawnDelayDefault;
    float minSpawnDelayDefault;
    [SerializeField] Attacker[] attackerPrefabArray = null;
    bool spawn = true;

   
    IEnumerator Start()
    {
        maxSpawnDelayDefault = maxSpawnDelay;
        minSpawnDelayDefault = minSpawnDelay;
        MakeItHardOrEasy(PlayerPrefsController.GetDifficulty());
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }
    public void KeepSpawning()
    {
        spawn = true;
    }
    private void ReturnDefaults()
    {
        maxSpawnDelay = maxSpawnDelayDefault;
        minSpawnDelay = minSpawnDelayDefault;
    }

    public void MakeItHardOrEasy(float index)
    {
        ReturnDefaults();
        maxSpawnDelay = maxSpawnDelay - index;
        minSpawnDelay = minSpawnDelay - index;
        if(minSpawnDelay <= 0)
        {
            minSpawnDelay = 0;
        }
    }
    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }
    private void Spawn(Attacker prefab)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);
        Attacker newAttacker = Instantiate(prefab, transform.position, spawnRotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
