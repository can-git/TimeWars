using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    AttackerSpawner[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        spawners = FindObjectsOfType<AttackerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
