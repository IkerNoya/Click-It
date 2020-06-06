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
        Upgrades.addScore += AutomaticScore;
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
        Upgrades.addScore -= AutomaticScore;

    }
}
