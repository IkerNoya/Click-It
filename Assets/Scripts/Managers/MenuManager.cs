using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameManager manager;
    bool isLoaded = false;
    private void Start()
    {
        manager = GameManager.Get();
    }
    public void ClickToGame()
    {
        if(isLoaded)
        {
            UIGame.inGame = true;
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }
        else
        {
            UIGame.inGame = true;
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
            manager.ResetValues();
        }
    }
    public void ClickToLoad()
    {
        FileStream fs = File.OpenRead("Assets/SavedData/SavedScores.txt");
        BinaryReader br = new BinaryReader(fs);
        manager.score = br.ReadInt32();
        manager.InitialScoreA = br.ReadInt32();
        manager.InitialScoreB = br.ReadInt32();
        manager.InitialScoreC = br.ReadInt32();
        manager.InitialScoreD = br.ReadInt32();
        manager.addedValue = br.ReadInt32();
        AutoClick.minusTimer = br.ReadSingle();
        manager.AutomaticAddedValue = br.ReadInt32();
        fs.Close();
        br.Close();
        if (manager.InitialScoreB > 4000)
        {
            AutoClick.ClickNow = true;
        }
        isLoaded = true;
    }

    public void ClickToDeleteSaves()
    {
        manager.ResetValues();
        FileStream fs = File.OpenWrite("Assets/SavedData/SavedScores.txt");
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(manager.score);
        bw.Write(manager.InitialScoreA);
        bw.Write(manager.InitialScoreB);
        bw.Write(manager.InitialScoreC);
        bw.Write(manager.InitialScoreD);
        bw.Write(manager.addedValue);
        bw.Write(AutoClick.minusTimer);
        bw.Write(manager.AutomaticAddedValue);
        fs.Close();
        bw.Close();
    }
    
    public void ClickToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ClickToQuit()
    {
        Application.Quit();
    }
}
