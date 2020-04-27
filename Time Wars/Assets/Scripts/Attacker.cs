using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        EffectOnOrClose();
    }
    public void EffectOnOrClose()
    {
        if (!gameObject.GetComponent<Enemy2>() && !gameObject.GetComponent<Enemy5>())
        {
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterEffectInt();
        }
    }
    void OnDestroy()
    {
        if (FindObjectOfType<KillStarDisplay>())
            FindObjectOfType<KillStarDisplay>().RemoveStars();
    }
}
