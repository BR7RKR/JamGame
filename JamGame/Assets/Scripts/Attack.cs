using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform gunPosition;
    [Space(10)]
    [SerializeField] private Transform head;
    
    private bool isAttacking;
    
    private PlayersArmory armory;
    private GameObject gunPrefab;
    private GameObject gun;

    private void Awake()
    {
        armory = GetComponent<PlayersArmory>();
        gunPrefab = armory.DiceRoll(); 
        gun = Instantiate(gunPrefab, gunPosition.position,gunPosition.rotation, gunPosition);
    }

    void Update()
    {
        SetShootingPoint();
        BulletGetting();
    }

    private void BulletGetting()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(gun);
            gunPrefab = armory.DiceRoll(); 
            gun = Instantiate(gunPrefab, gunPosition.position,gunPosition.rotation, gunPosition);
        }
    }
    
    private void SetShootingPoint()
    {
        Vector2Int _halfScreenDims = new Vector2Int(Screen.width / 2, Screen.height / 2);
        Vector2 mouseDirection = new Vector2(Input.mousePosition.x - _halfScreenDims.x, Input.mousePosition.y - _halfScreenDims.y);
        
        head.transform.localEulerAngles =  new Vector3(0, Vector3.SignedAngle(mouseDirection,Vector3.up,Vector3.forward)-110f, 0);
    }
}