using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayersArmory : MonoBehaviour
{
    [SerializeField] private MovePlayer plmv;
    [SerializeField] private Animator anim;
    [SerializeField] private float reloadCooldown = 0f;
    private int reloadsCount = 1;
    public GameObject[] bullets;
    private WaitForSeconds cd;

    private void Awake()
    {
        cd = new WaitForSeconds(1.66f);
        plmv = GetComponent<MovePlayer>();
    }

    void Update()
    {
        reloadCooldown += Time.deltaTime;
        if (reloadCooldown >= 15f)
        {
            reloadCooldown = 0f;
            if (reloadsCount < 3)
                reloadsCount++;
        }
    }
    public GameObject DiceRoll()
    {
        int max = bullets.Length;
        GameObject ShootingBullet = null;
        if (bullets != null)
        {
            if (reloadsCount > 0)
            {
                StartCoroutine(AnimationSwapping());
                ShootingBullet = bullets[Random.Range(0,max)];
                reloadsCount--;
            }
        }
        return ShootingBullet;
    }

    private IEnumerator AnimationSwapping()
    {
        plmv.enabled = false;
        anim.SetBool("IsMoving",false);
        anim.SetBool("IsReloading",true);
        yield return cd;
        anim.SetBool("IsReloading",false);
        plmv.enabled = true;
    }
}