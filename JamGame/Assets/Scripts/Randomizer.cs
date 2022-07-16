using System;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    private GameObject[] skills;
    private GameObject[] rareSkills;
    private GameObject[] showedSkills;

    private void Start()
    {
        skills = new GameObject[50];
        rareSkills = new GameObject[15];
        showedSkills = new GameObject[3];
    }

    private void GetRandom()
    {
        System.Random random = new System.Random();

        for (int i = 0; i < showedSkills.Length; )
        {
            bool continueFlag = true;

            if (random.Next(0, skills.Length + rareSkills.Length - 1) < 50)
                showedSkills[i] = skills[random.Next(0, skills.Length)];
            else
                showedSkills[i] = rareSkills[random.Next(0, rareSkills.Length)];

            for (int j = 0; j < i; j++)
                if (showedSkills[i] == showedSkills[j])
                {
                    continueFlag = false;
                    break;
                }

            if (continueFlag) i++;
        }
    }
}

