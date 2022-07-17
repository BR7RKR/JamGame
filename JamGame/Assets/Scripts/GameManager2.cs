using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance = null;
    
    [SerializeField] private PickUpCoin _coinManager;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    
    private bool isPaused;
    public static bool IsGameOver { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(this);
    }
    
    private void Start()
    {
        
        isPaused = false;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Continue();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        pausePanel.SetActive(true);
    }
    public void Continue()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0.0f;
        gameOverPanel.SetActive(true);
    }
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coins", _coinManager.totalCoins);
    }

    private void OnApplicationQuit()
    {
        SaveCoins();
    }
}
