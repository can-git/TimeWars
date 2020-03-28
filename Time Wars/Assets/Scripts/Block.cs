using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool isBlocking = false;
    GameObject[] prefabs;

    void Update()
    {
        prefabs = GameObject.FindGameObjectsWithTag("Hero");
    }
    public void UpdateState()
    {
        if (isBlocking)
        {
            isBlocking = false;
            DeactivateBlocking();
            foreach (GameObject prefab in prefabs)
            {
                prefab.GetComponent<Health>().isBlocked(false);
            }
        }
        else
        {
            isBlocking = true;
            foreach (GameObject prefab in prefabs)
            {
                prefab.GetComponent<Health>().isBlocked(true);
            }
            ActivateBlocking();
        }
    }
    private void ActivateBlocking()
    {
        foreach(GameObject prefab in prefabs)
        {
            if(prefab.name != "Hero5")
            {
                prefab.GetComponent<Animator>().SetTrigger("Block");
            }
        }
    }
    private void DeactivateBlocking()
    {
        foreach (GameObject prefab in prefabs)
        {
            prefab.GetComponent<Animator>().speed = 1;
        }
    }
    public void KeepGoing()
    {
        foreach (GameObject prefab in prefabs)
        {
            if (prefab.GetComponent<Animator>().GetBool("isAttacking") == true)
            {
                prefab.GetComponent<Animator>().Play("Attack");
            }
            else if(prefab.GetComponent<Animator>().GetBool("isAttacking") == false)
            {
                if (prefab.name == "Hero4")
                {
                    prefab.GetComponent<Animator>().Play("Idle");
                }
                else
                {
                    prefab.GetComponent<Animator>().Play("Walk");
                }
                
            }
        }
    }
    public void Freeze()
    {
        gameObject.GetComponent<Animator>().speed = 0;
    }
}
