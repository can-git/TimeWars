using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    void Update()
    {
        EffectOnOrClose();
    }
    public void EffectOnOrClose()
    {
        if(gameObject.tag != "Stone")
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterEffectInt();
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
