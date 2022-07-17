using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageOfTheWeapon : MonoBehaviour
{
    [SerializeField] private Image currentImage;
    [SerializeField] private Sprite[] images;
    [SerializeField] private PlayersArmory plyrsmr;

    private void Update()
    {
        currentImage.sprite = images[plyrsmr.number];
    }
}
