using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSW : MonoBehaviour
{
    public bool isRunning;

    public int score; 

    public PlayerSW player; 

    public static GameManagerSW instance;

    void Awake()
    {
        instance = this; 
        isRunning = true; 
    }

    public void AddPoints(int points)
    {
        score += points; 
    }

    void Update()
    {
        if(player == null)
        {
            isRunning = false; 
        }
    }
}
