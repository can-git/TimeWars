using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    bool isBlocking = false;
    GameObject[] prefabs;
    ChangeImage imageOfShield;

    void Start()
    {
        imageOfShield = gameObject.GetComponent<ChangeImage>();
    }

    void Update()
    {
        prefabs = GameObject.FindGameObjectsWithTag("Hero");
    }
    public void UpdateState()
    {
        if (isBlocking)
        {
            imageOfShield.ChangeImageOfShield(false);
            isBlocking = false;
            DeactivateBlocking();
            foreach (GameObject prefab in prefabs)
            {
                prefab.GetComponent<Health>().isBlocked(false);
            }
            StartCoroutine(Wait());
        }
        else
        {
            imageOfShield.ChangeImageOfShield(true);
            isBlocking = true;
            foreach (GameObject prefab in prefabs)
            {
                prefab.GetComponent<Health>().isBlocked(true);
            }
            ActivateBlocking();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    private void ActivateBlocking()
    {
        foreach(GameObject prefab in prefabs)
        {
            if(!prefab.GetComponent<Shooter>())
            {
                prefab.GetComponent<Animator>().Play("Block");
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

                if (prefab.GetComponent<Hero4>())
                {
                    prefab.GetComponent<Animator>().Play("Idle");
                }
                else if(prefab.GetComponent<Hero6>())
                {
                    
                    prefab.GetComponent<Animator>().Play("Run");
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
