using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColldier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Hero Projectile" || otherCollider.tag == "Attacker Projectile")
        {
            Destroy(otherCollider.gameObject);
        }
        if(gameObject.name == "Damage Collider")
        {
            if (otherCollider.tag == "Attacker")
            {
                //FindObjectOfType<LivesDisplay>().TakeLife();
                FindObjectOfType<GameTimer>().PrizeForEnemies();
                GameObject.FindWithTag("Slider Enemy").GetComponent<Animator>().SetTrigger("Attack");
                GameObject.FindWithTag("Slider Hero").GetComponent<Animator>().SetTrigger("Block");
                Destroy(otherCollider.gameObject);
            }
        }
        else if(gameObject.name == "Damage Collider Right")
        {
            if (otherCollider.tag == "Hero")
            {
                FindObjectOfType<GameTimer>().PrizeForHeros();
                GameObject.FindWithTag("Slider Hero").GetComponent<Animator>().SetTrigger("Attack");
                GameObject.FindWithTag("Slider Enemy").GetComponent<Animator>().SetTrigger("Block");
                Destroy(otherCollider.gameObject);
            }
        }
        
    }
}
