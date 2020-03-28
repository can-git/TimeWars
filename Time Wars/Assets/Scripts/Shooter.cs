using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] GameObject projectilePos = null;
    AttackerSpawner myLaneSpawner = null;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAttackerInLane())
        {
            animator.SetBool("IsShooting", true);
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
    }

    private bool isAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void Fire(float damage)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
        Instantiate(projectile, projectilePos.transform.position, spawnRotation);
    }
}
