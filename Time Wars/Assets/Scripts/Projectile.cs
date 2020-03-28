using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 20;
    bool isHero;

    void Start()
    {
        if (gameObject.tag == "Hero Projectile")
        {
            isHero = true;
        }
        else if (gameObject.tag == "Enemy Projectile")
        {
            isHero = false;
        }
    }
    void Update()
    {
        if (isHero)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 5);
        }
        else if (!isHero)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 5);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        if (isHero)
        {
            var attacker = otherCollider.GetComponent<Attacker>();
            if (attacker && health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (!isHero)
        {
            var defender = otherCollider.GetComponent<Defender>();
            if (defender && health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
        


    }
}
