using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSW : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject restartPanel;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText; 

    public bool isRunning;

    public int score; 

    public PlayerSW player; 

    public static GameManagerSW instance;

    void Awake()
    {
        instance = this; 
        isRunning = true; 
    }

    void Start()
    {
        restartPanel.SetActive(!isRunning);
        inGamePanel.SetActive(isRunning);
        Time.timeScale = 1f; 
    }

    public void GameOver()
    {
        isRunning = false;
        restartPanel.SetActive(!isRunning);
        inGamePanel.SetActive(isRunning);
        Time.timeScale = 0f; 
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
        
        scoreText.text = score.ToString();
        healthText.text = player.health.ToString();
    }
}
