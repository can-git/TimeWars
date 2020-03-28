using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float maxSpawnDelay = 7f;
    [SerializeField] float minSpawnDelay = 3f;
    [SerializeField] Attacker[] attackerPrefabArray=null;
    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
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
