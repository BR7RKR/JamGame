using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int highscore = 0;
    private void Awake() //sample awake method to get all stats in upgrade menu
    {
        highscore = GetSavedScore();
        scoreText.text = "Highscore: " + highscore;
    }
    
    //============ M O N E Y =================//

    // получить кол-во денег игрока из сейва
    public int GetSavedScore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }

    //сохранить кол-во денег в сейв (использовать при ЗАВЕРШЕНИИ ЛВЛА)
    public void SetSavedScore(int scoreCount)
    {
        PlayerPrefs.SetInt("highscores", scoreCount);
        PlayerPrefs.Save(); // для правильной работы на WebGL
    }
    
}
