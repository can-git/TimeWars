using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNameText : MonoBehaviour
{
    Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        levelText = gameObject.GetComponent<Text>();
        levelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex - 3).ToString();
    }
}
