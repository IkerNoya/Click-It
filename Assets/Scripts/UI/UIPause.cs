using System.IO;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    GameManager manager;
    private void Start()
    {
        manager = GameManager.Get();
    }
    public void OnClickContinue()
    {
        Time.timeScale = 1;
        UIGame.inGame = true;
        SceneManager.UnloadSceneAsync("Pause");
    }
    public void OnClickSave()
    {
        FileStream fs = File.OpenWrite(manager.dataPath + "/SavedData/SavedScores.txt");
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
    public void OnClickMenu()
    {
        SceneManager.UnloadSceneAsync("Pause");
        SceneManager.LoadScene("Menu");
        manager.ResetValues();
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
