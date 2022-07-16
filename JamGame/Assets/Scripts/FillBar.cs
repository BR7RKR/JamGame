using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private PickUpCoin _Coins; 
    [SerializeField] private GameObject _fillbar;
    private Image _filler;

    void Start()
    {
        _fillbar.SetActive(true);
        _filler = _fillbar.transform.GetChild(0).GetComponent<Image>();
    }
    
    void Update()
    {
        ChangeStripSize();
    }

    private void ChangeStripSize()
    { 
        _filler.fillAmount = _Coins.FinalXP;
    }
}
