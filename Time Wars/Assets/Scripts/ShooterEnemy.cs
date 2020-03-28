using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] GameObject projectilePos = null;
   
    public void Fire(float damage)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 0, -90);
        Instantiate(projectile, projectilePos.transform.position, spawnRotation);
    }
    public void StopWalking()
    {
        GetComponent<Animator>().Play("Idle");
    }
    public void KeepWalking()
    {
        GetComponent<Animator>().Play("Walk");
    }
}
