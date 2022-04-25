using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    [Header("Componentes")] //paineis e texto de pontuação
    [SerializeField] Text scoreText; 
    [SerializeField] GameObject InGamePanel;
    [SerializeField] GameObject RestartPanel; 

    [Header("Variáveis")] //Variáveis para dificuldade
    [SerializeField] float difficultInterval;
    float difficultTimer; 
    
    public bool isRunning; 
    float score;

    public static GameManager instance; 

    void Awake()
    {
        instance = this; 
        isRunning = true; 
        score = 0f; 
    }

    void Start()
    {
        difficultTimer = difficultInterval;
        Time.timeScale = 1f; 
        Physics.gravity = new Vector3(0f,-0.4f,0f);
        InGamePanel.SetActive(true);
        RestartPanel.SetActive(false);
    }
    //Função que define o fim do jogo
    public void GameOver()
    {
        isRunning = false;
        InGamePanel.SetActive(false);
        RestartPanel.SetActive(true);
        Debug.Log("O jogo terminou");

    }
    //função para o botão de restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //função para o botão do mainmenu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Atualiza pontuação
    //Aumenta a dificuldade
    void Update()
    {
        if(isRunning)
        {
            score += Time.deltaTime;
            scoreText.text = ((int)score).ToString();
            difficultTimer-=Time.deltaTime; 
            if(difficultTimer<=0)
            {
                Time.timeScale+= 0.1f;
                difficultTimer = difficultInterval;
                Debug.Log("Dificuldade aumentou");
            }
        }
    }
}
