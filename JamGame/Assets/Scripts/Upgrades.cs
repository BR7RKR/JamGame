using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private Health hlth;
    public static int damageAmplify = 1;
    [SerializeField] private MovePlayer mvplr;
    
    public void UpgradeHealth()
    {
        hlth.ReceiveHealing(20);
    }

    public void UpgradeDamage()
    {
        damageAmplify++;
    }

    public void UpgradeSpeed()
    {
        mvplr._velocity += 1;
    }
}
