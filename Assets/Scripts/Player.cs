using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void AddScore();
    public static event AddScore addScore;
    public void OnClickObjective()
    {
        addScore();
    }
}
