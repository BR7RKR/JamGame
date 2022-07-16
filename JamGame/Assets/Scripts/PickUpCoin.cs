using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public int FinalXP { get; private set; }

    [SerializeField]private GameObject _player;
    
    private int _amount;

    // Update is called once per frame
    void Update()
    {
        CountFinalXP();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _amount++;
        }
    }

    /// <summary>
    /// Метод считает итоговое кол-во опыта с монетки
    /// </summary>
    private void CountFinalXP()
    {
        FinalXP = _amount;
        //TODO: придумать формулу
    }
}
