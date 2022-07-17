﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Team Settings")]
    [Tooltip("The team associated with this damage")]
    public int teamId = 0;

    [Header("Health Settings")]
    [Tooltip("The default health value")]
    public int defaultHealth = 1;
    [Tooltip("The maximum health value")]
    public int maxHealth = 1;
    [Tooltip("The current in game health value")]
    public int currentHealth = 1;
    [Tooltip("Invulnerability duration, in seconds, after taking damage")]
    public float invincibilityTime = 3f;
    [Tooltip("Whether or not this health is always invincible")]
    public bool isAlwaysInvincible = false;

    [Header("Lives settings")]
    [Tooltip("Whether or not to use lives")]
    public bool useLives = false;
    [Tooltip("Current number of lives this health has")]
    public int currentLives = 3;
    [Tooltip("The maximum number of lives this health can have")]
    public int maxLives = 5;
    
    void Start()
    {
        SetRespawnPoint(transform.position);
    }
    
    void Update()
    {
        InvincibilityCheck();
    }
    
    private float timeToBeDamaged = 0;
    private bool isInvincable = false;
    
    private void InvincibilityCheck()
    {
        if (timeToBeDamaged <= Time.time)
        {
            isInvincable = false;
        }
    }
    
    private Vector3 respawnPosition;
    
    public void SetRespawnPoint(Vector3 newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }
    
    void Respawn()
    {
        transform.position = respawnPosition;
        currentHealth = defaultHealth;
    }
    
    public void TakeDamage(int damageAmount)
    {
        if (isInvincable || isAlwaysInvincible)
        {
            return;
        }
        else
        {
            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, transform.rotation, null);
            }
            timeToBeDamaged = Time.time + invincibilityTime;
            isInvincable = true;
            currentHealth -= damageAmount;
            CheckDeath();
        }
    }
    
    public void ReceiveHealing(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        CheckDeath();
    }

    [Header("Effects & Polish")]
    [Tooltip("The effect to create when this health dies")]
    public GameObject deathEffect;
    [Tooltip("The effect to create when this health is damaged")]
    public GameObject hitEffect;
    
    bool CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Die();
            return true;
        }
        return false;
    }
    
    public void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation, null);
        }

        if (useLives)
        {
            HandleDeathWithLives();
        }
        else
        {
            HandleDeathWithoutLives();
        }      
    }
    
    void HandleDeathWithLives()
    {
        currentLives -= 1;
        if (currentLives > 0)
        {
            Respawn();
        }
        else
        {
            if (gameObject.tag == "Player" && GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
            if (gameObject.GetComponent<Enemy>() != null)
            {
                //gameObject.GetComponent<Enemy>().DoBeforeDestroy();
            }
            Destroy(this.gameObject);
        }
    }
    
    void HandleDeathWithoutLives()
    {
        if (gameObject.tag == "Player" && GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }
        if (gameObject.GetComponent<Enemy>() != null)
        {
            //gameObject.GetComponent<Enemy>().DoBeforeDestroy();
        }
        Destroy(this.gameObject);
    }
}
