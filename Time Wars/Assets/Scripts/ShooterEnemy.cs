using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] GameObject projectilePos = null;

    const string PROJECTILES_PARENT_NAME = "Projectiles";
    GameObject projectilesParent;

    private void Start()
    {
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILES_PARENT_NAME);
        }
    }

    public void StopWalking()
    {
        GetComponent<Animator>().Play("Idle");
    }
    public void KeepWalking()
    {
        GetComponent<Animator>().Play("Walk");
    }
    public void Fire(float damage)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 0, -90);
        GameObject projectiles = Instantiate(projectile, projectilePos.transform.position, spawnRotation) as GameObject;
        projectiles.transform.parent = projectilesParent.transform;
    }
}
