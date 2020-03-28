﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Attacker>())
        {
            GetComponent<isAttacking>().Attack(otherObject);
        }
    }

}
