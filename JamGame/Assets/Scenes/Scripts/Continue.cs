using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Continue : MonoBehaviour
{
    private Randomizer parentMenu;
    private GameObject[] activeCards;
    private void Start()
    {
        activeCards = GameObject.FindGameObjectsWithTag("Upgrade");
        parentMenu = GetComponentInParent<Randomizer>();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        foreach (GameObject gCard in activeCards)
            Destroy(gCard);
        parentMenu.gameObject.SetActive(false);
    }
}
