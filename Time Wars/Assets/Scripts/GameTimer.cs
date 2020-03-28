using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 5;
    bool triggeredLevelFinished = false;
    Slider slider;
    float maxNum=10f;
    float minNum = 0f;
    float currentNum = 5;

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
        bool timerFinished = maxNum <= slider.value;
        if (maxNum <= slider.value)
        {
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
        if (minNum >= slider.value)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
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
