using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private PickUpCoin _Coins;
    [SerializeField] private Image _filler;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI coinsAmount;

    void Update()
    {
        ChangeStripSize();
        SetLevelInfo();
    }

    private void ChangeStripSize()
    { 
        _filler.fillAmount = _Coins.collectedCoins/_Coins.FinalXP;
    }

    private void SetLevelInfo()
    {
        levelText.text = "LV:" + _Coins.level.ToString();
        coinsAmount.text = _Coins.totalCoins.ToString();
    }
}
