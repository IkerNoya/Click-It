﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ClickToGame()
    {
        SceneManager.LoadScene("Game");
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
