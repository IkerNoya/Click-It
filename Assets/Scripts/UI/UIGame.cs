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
    int InitialScoreA = 2000;
    int percentageA = 20;
    int InitialScoreB = 4000;
    int percentageB = 75;
    int InitialScoreC = 2000;
    int InitialScoreD = 2000;

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
        if(Upgrades.minusTimer<0.5f)
            UpgradeBPrice.text = "Price " + InitialScoreB;
        else if(Upgrades.minusTimer >= 0.5f)
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
        if(manager.score >= InitialScoreB && Upgrades.minusTimer < 0.5f)
        {
            Upgrades.ClickNow = true;
            Upgrades.minusTimer += 0.1f;                    // Para testear, modificar mas adelante para evitar el sobreuso de static
            Upgrades.timerLimit -= Upgrades.minusTimer; 
            manager.score -= InitialScoreB;
            manager.AutomaticAddedValue += manager.initialValue;
            InitialScoreB += Percentage(InitialScoreB, percentageB);
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
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }
}
