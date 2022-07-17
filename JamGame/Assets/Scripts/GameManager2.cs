using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance = null;
    
    [SerializeField] private PickUpCoin _coinManager;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
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
    }
    public void Continue()
    {
    }

    public void GameOver()
    {
        IsGameOver = true;
        SceneManager.LoadScene("MainMenu");
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
