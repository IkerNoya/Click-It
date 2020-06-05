using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIGame : MonoBehaviour
{
    public Text Score;
    public Text UpgradeAPrice;
    GameManager manager;
    int InitialScoreA = 2000;
    int percentageA = 20;
    int InitialScoreB = 2000;
    int InitialScoreC = 2000;
    int InitialScoreD = 2000;

    private void Start()
    {
        manager = GameManager.Get();
    }
    private void Update()
    {
        Score.text = "Score: " + manager.score;
        UpgradeAPrice.text = "Price " + InitialScoreA;
    }
    int Percentage(int value, int percentage)
    {
        return ((value * percentage) / 100);
    }
    public void OnClickUpgradeA()
    {
        if (manager.score >= InitialScoreA)
        {
            manager.score -= InitialScoreA;
            manager.addedValue += manager.initialValue;
            InitialScoreA += Percentage(InitialScoreA, percentageA);
            percentageA += 5;
        }
    }
    public void OnClickUpgradeB()
    {

    }
    public void OnClickUpgradeC()
    {

    }
    public void OnClickUpgradeD()
    {

    }
    public void OnClickPause()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }
}
