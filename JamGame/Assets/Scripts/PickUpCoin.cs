using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public int totalCoins;
    public int collectedCoins;
    public float FinalXP { get; private set; }
    public int level;

    [SerializeField] private GameObject levelUpMenu;

    private void Start()
    {
        levelUpMenu.SetActive(false);
        totalCoins = 0;
        level = 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        CountFinalXP();
        LevelUp();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collectedCoins+=5;
            totalCoins = collectedCoins;
        }
    }
    
    private void CountFinalXP()
    {
        FinalXP = level * 80 * 1.25f;
    }
    private void LevelUp()
    {
        if (collectedCoins >= FinalXP)
        {
            level++;
            collectedCoins = 0;
            Time.timeScale = 0f;
            levelUpMenu.SetActive(true);
        }
    }
}
