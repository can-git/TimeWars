using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 20;
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 5);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var defender = otherCollider.GetComponent<Defender>();

        if (defender && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        

    }
}
