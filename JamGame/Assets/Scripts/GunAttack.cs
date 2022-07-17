using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttack : MonoBehaviour
{
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float attackTime;
    private GameObject vertelka;
    private WaitForSeconds AttackTimer;
    private Coroutine activeCoroutine;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AttackTimer = new WaitForSeconds(attackTime);
        vertelka = GameObject.FindWithTag("PlayerMesh");
    }

    private void Update()
    {
        Attacking();
    }

    private void Attacking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (activeCoroutine == null)
            {
                activeCoroutine = StartCoroutine(WaitForAttackToFinish());
            }
        }
    }

    private IEnumerator WaitForAttackToFinish()
    {
        Instantiate(bullet, bulletPosition.position, vertelka.transform.rotation);
        audioSource.Play();
        yield return AttackTimer;
        activeCoroutine = null;
    }
}
