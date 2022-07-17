using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance = null;

    private AudioSource audioSource;
    public static int coins
    {
        get { return coins; }
        set { coins = value; }
    }

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    private bool isPaused;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(this);
    }

    private void Start()
    {
        HandleStartUp();
        isPaused = false;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
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

    private void HandleStartUp()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            coins = 0;
            PlayerPrefs.SetInt("coins", 0);
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

    public void AddCoins(int scoreValue)
    {
        coins += scoreValue;
    }
    private void ResetCoinsInGame()
    {
        coins = 0;
    }
    private void ResetCoins()
    {
        coins = 0;
        PlayerPrefs.SetInt("coins", 0);
    }
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coins", coins);
    }

    public void GameOver()
    {
        audioSource.Play();
        Time.timeScale = 0.0f;
        gameOverPanel.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        SaveCoins();
    }
}