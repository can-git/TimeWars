using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject body;
  
    public void DealDamage(float damage)
    {
        health -= damage;

        StartCoroutine("color");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator color()
    {
        body.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        body.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
