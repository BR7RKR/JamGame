using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance = null;
    public static int coins
    {
        get { return coins; }
        set { coins = value; }
    }

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
        Debug.Log("GameOver!");
    }

    private void OnApplicationQuit()
    {
        SaveCoins();
    }
}
