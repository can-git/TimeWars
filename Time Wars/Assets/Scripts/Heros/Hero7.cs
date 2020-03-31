using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero7 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Attacker>())
        {
            GetComponent<isAttacking>().Attack(otherObject);
        }
    }
}
