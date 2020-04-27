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
    const string PROJECTILES_PARENT_NAME = "Projectiles";
    GameObject projectilesParent;

    private void Start()
    {
        CreateProjectileParent();
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void CreateProjectileParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILES_PARENT_NAME);
        }
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
        GameObject projectiles = Instantiate(projectile, projectilePos.transform.position, spawnRotation) as GameObject;
        projectiles.transform.parent = projectilesParent.transform;
    }
}
