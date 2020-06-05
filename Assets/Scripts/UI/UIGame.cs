using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIGame : MonoBehaviour
{
    public Text Score;
    GameManager manager;

    private void Start()
    {
        manager = GameManager.Get();
    }
    private void Update()
    {
        Score.text = "Score: " + manager.score;
    }
}
