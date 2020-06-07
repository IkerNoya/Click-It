using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int score;
    public int initialValue = 50;
    public int addedValue = 50;
    public int AutomaticAddedValue = 50;
    public int InitialScoreA = 2000;
    public int percentageMoreClicks = 20;
    public int InitialScoreB = 4000;
    public int percentageAutoClicks = 75;
    public int InitialScoreC = 2000;
    public int InitialScoreD = 2000;


    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        UIGame.addScore += Score;
        AutoClick.addScore += AutomaticScore;
    }
    void Score()
    {
        score += addedValue;
    }
    void AutomaticScore()
    {
        score += AutomaticAddedValue;
    }
    private void OnDisable()
    {
        UIGame.addScore -= Score;
        AutoClick.addScore -= AutomaticScore;

    }
    public void ResetValues()
    {
        score = 0;
        InitialScoreA = 2000;
        InitialScoreB = 4000;
        InitialScoreC = 2000;
        InitialScoreD = 2000;
        addedValue = 50;
        AutoClick.minusTimer = 0;
        AutomaticAddedValue = 50;
    }
}
