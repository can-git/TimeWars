using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillStarDisplay : MonoBehaviour
{
    [SerializeField] int kill = 5;
    Text killText;

    void Start()
    {
        killText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        killText.text = kill.ToString();
    }

    public void RemoveStars()
    {
        if (kill >= 0)
        {
            kill--;
            if (kill == 0)
            {
                if (GameObject.Find("Damage Collider Right"))
                {
                    GameObject.Find("Damage Collider Right").GetComponent<DamageColldier>().KillIsDone();
                }
                if (GameObject.Find("Kill Star Image"))
                {
                    GameObject.Find("Kill Star Image").GetComponent<Animator>().SetTrigger("isHigh");
                }
                Destroy(gameObject);
            }
        }
        UpdateDisplay();
    }
    public int GetStars()
    {
        return kill;
    }
}
