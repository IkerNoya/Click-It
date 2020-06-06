using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    public void OnClickContinue()
    {
        SceneManager.UnloadSceneAsync("Pause");
    }
    public void OnClickSave()
    {
        throw new NotImplementedException();
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
