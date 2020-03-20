using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectilePos;
    public void Fire(float damage)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 0, -90);
        Instantiate(projectile, projectilePos.transform.position, spawnRotation);
    }
}
