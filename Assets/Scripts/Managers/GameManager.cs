using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int score;
    public int initialValue = 50;
    public int addedValue = 50;

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
        Player.addScore += Score;
    }
    void Score()
    {
        score += addedValue;
    }
    private void OnDisable()
    {
        Player.addScore -= Score;
    }
}
