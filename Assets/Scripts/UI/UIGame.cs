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
    public static bool inGame = true;
    public delegate void AddScore();
    public static event AddScore addScore;

    private void Start()
    {
        manager = GameManager.Get();
    }
    private void Update()
    {
        ScoreText.text = manager.score.ToString();
        UpgradeAPrice.text = "Price " + manager.InitialScoreA;
        if(AutoClick.minusTimer<0.5f)
            UpgradeBPrice.text = "Price " + manager.InitialScoreB;
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
            if (manager.score >= manager.InitialScoreA)
            {
                manager.score -= manager.InitialScoreA;
                manager.addedValue += manager.initialValue;
                manager.InitialScoreA += Percentage(manager.InitialScoreA, manager.percentageMoreClicks);
                manager.percentageMoreClicks += 5;
            }
        }
    }
    public void OnClickUpgradeB()
    {
        if (inGame)
        {
            if (manager.score >= manager.InitialScoreB && AutoClick.minusTimer < 0.5f)
            {
                AutoClick.ClickNow = true;
                AutoClick.minusTimer += 0.1f;                    // Para testear, modificar mas adelante para evitar el sobreuso de static
                AutoClick.timerLimit -= AutoClick.minusTimer;
                manager.score -= manager.InitialScoreB;
                manager.AutomaticAddedValue += manager.initialValue;
                manager.InitialScoreB += Percentage(manager.InitialScoreB, manager.percentageAutoClicks);
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
