using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersArmory : MonoBehaviour
{
    public GameObject[] bullets;

    public GameObject DiceRoll()
    {
        int max = bullets.Length;
        GameObject ShootingBullet = null;
        if (bullets != null)
        {
            ShootingBullet = bullets[Random.Range(0,max)];
        }
        return ShootingBullet;
    }
}
