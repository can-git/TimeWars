using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxSpawnDelay = 7f;
    [SerializeField] float minSpawnDelay = 3f;
    [SerializeField] Attacker attackerPrefab;
    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Quaternion spawnRotation = Quaternion.Euler(0,180, 0);
        Instantiate(attackerPrefab, transform.position, spawnRotation);
    }

}
