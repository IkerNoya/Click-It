using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIGame : MonoBehaviour
{
    public Text ScoreText;
    public Text UpgradeAPrice;
    public Text UpgradeBPrice;
    GameManager manager;
    public int InitialScoreA = 2000;
    int percentageA = 20;
    public int InitialScoreB = 4000;
    int percentageB = 75;
    public int InitialScoreC = 2000;
    public int InitialScoreD = 2000;

    public static bool inGame = true;
    public delegate void AddScore();
    public static event AddScore addScore;

    private void Start()
    {
        manager = GameManager.Get();
    }
    private void Update()
    {
        ScoreText.text = "Score: " + manager.score;
        UpgradeAPrice.text = "Price " + InitialScoreA;
        if(AutoClick.minusTimer<0.5f)
            UpgradeBPrice.text = "Price " + InitialScoreB;
        else if(AutoClick.minusTimer >= 0.5f)
            UpgradeBPrice.text = " Maxed";
    }
    public void OnClickObjective()
    {
        addScore();
    }
    int Percentage(int value, int percentage)
    {
        return ((value * percentage) / 100);
    }
    public void OnClickUpgradeA()
    {
        if (inGame)
        {
            if (manager.score >= InitialScoreA)
            {
                manager.score -= InitialScoreA;
                manager.addedValue += manager.initialValue;
                InitialScoreA += Percentage(InitialScoreA, percentageA);
                percentageA += 5;
            }
        }
    }
    public void OnClickUpgradeB()
    {
        if (inGame)
        {
            if (manager.score >= InitialScoreB && AutoClick.minusTimer < 0.5f)
            {
                AutoClick.ClickNow = true;
                AutoClick.minusTimer += 0.1f;                    // Para testear, modificar mas adelante para evitar el sobreuso de static
                AutoClick.timerLimit -= AutoClick.minusTimer;
                manager.score -= InitialScoreB;
                manager.AutomaticAddedValue += manager.initialValue;
                InitialScoreB += Percentage(InitialScoreB, percentageB);
            }
        }
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
        inGame = false;
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }
}
