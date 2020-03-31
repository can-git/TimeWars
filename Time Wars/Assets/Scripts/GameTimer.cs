using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    //[Tooltip("Our level timer in seconds")]
    //[SerializeField] float levelTime = 5;
    Slider slider;
    float maxNum=10f;
    float minNum = 0f;
    float currentNum = 5;
    bool triggeredLevelFinished = false;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 5.0f;
        maxNum = GetComponent<Slider>().maxValue;
        minNum = GetComponent<Slider>().minValue;
        currentNum = slider.value;
    }

    void Update()
    {
        if (triggeredLevelFinished) { return; }
        bool timerFinished = maxNum <= slider.value;
        if (maxNum <= slider.value)
        {
            triggeredLevelFinished = true;
            FindObjectOfType<LevelController>().LevelLoosed();
        }
        if (minNum >= slider.value)
        {
            triggeredLevelFinished = true;
            FindObjectOfType<LevelController>().LevelSuccessed();
        }
    }
    private void UpdateValue()
    {
        slider.value = currentNum;
    }
    public void PrizeForEnemies()
    {
        currentNum++;
        UpdateValue();

    }
    public void PrizeForHeros()
    {
        currentNum--;
        UpdateValue();
    }

}
