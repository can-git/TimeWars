﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject healthBar = null;
    int cost;
    float eachTemp;
    Animator animator;
    Vector2 b;
    bool ifBlocked = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        cost = Mathf.FloorToInt(health);
        if (healthBar)
        {
            b = healthBar.GetComponent<Transform>().localScale;
            eachTemp = b.x / health;
        }
    }

    public void DealDamage(float damage)
    {
        if (healthBar)
        {
            float temp = eachTemp * damage;

            b.x = b.x - temp;

            healthBar.GetComponent<Transform>().localScale = b;
        }

        if (ifBlocked)
        {
            health -= damage / 2;
        }
        else
        {
            health -= damage;
        }

        StartCoroutine(color());
        if (health <= 0)
        {
            //GetComponent<BoxCollider2D>().enabled = false;
            //StartCoroutine(die());
            if (gameObject.tag == "Attacker")
            {
                FindObjectOfType<StarDisplay>().AddStars(cost / 2);
            }
            else
            {
                FindObjectOfType<StarDisplay>().AddStars(cost);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator die()
    {
        animator.SetTrigger("isDying");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    IEnumerator color()
    {
        gameObject.transform.Find("Body").GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.Find("Body").GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void isBlocked(bool state)
    {
        ifBlocked = state;
    }
}
