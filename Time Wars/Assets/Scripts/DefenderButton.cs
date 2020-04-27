using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{

    [SerializeField] Defender defenderPrefab=null;
    int Cost = 100;
    int starAmount;
    void Start()
    {
        Cost = defenderPrefab.GetStarCost();
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    void Update()
    {
        starAmount = FindObjectOfType<StarDisplay>().GetStars();
        if (starAmount >= Cost)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(89, 89, 89, 255);
        }
    }
    private void OnMouseDown()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
        {
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        }
        else
        {
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(null);
        }

    }
}
