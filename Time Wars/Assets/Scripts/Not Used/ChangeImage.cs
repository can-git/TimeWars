using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{

    [SerializeField] public Sprite ShieldI;
    [SerializeField] public Sprite SwordI;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = ShieldI;
    }
    public void ChangeImageOfShield(bool isBlocked)
    {
        if (isBlocked)
        {
            gameObject.GetComponent<Image>().sprite = SwordI;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = ShieldI;
        }
    }
}
