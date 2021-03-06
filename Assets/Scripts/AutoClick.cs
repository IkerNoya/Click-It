﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    float timer = 0;
    public static float timerLimit = 1.7f;
    public static float minusTimer = 0;
    public static bool ClickNow = false;
    public delegate void AddScore();
    public static event AddScore addScore;

    void Update()
    {
        if (!ClickNow)
            return;
        timer += Time.deltaTime;
        if (timer >= timerLimit)
        {
            addScore();
            timer = 0;
        }
    }
}