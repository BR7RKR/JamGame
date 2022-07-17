using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Attack : MonoBehaviour
{
    [Header("Weapon Data")] 
    public float attackingCooldown;
    public GameObject bulletPrefab;
    [Space(10)]
    [SerializeField] private Transform bulletPositionRotation;
    [SerializeField] private Transform actualBulletPosition;
    [SerializeField] private Transform head;

    private WaitForSeconds AttackTimer;
    private bool isAttacking;
    
    private Coroutine activeCoroutine;
    private PlayersArmory armory;

    private void Awake()
    {
        armory = GetComponent<PlayersArmory>();
    }

    void Update()
    {
        SetShootingPoint();
        BulletGetting();
        Attacking();
    }

    private void BulletGetting()
    {
        if (Input.GetKey("r"))
            bulletPrefab = armory.DiceRoll();
    }
    
    private void Attacking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (activeCoroutine == null && bulletPrefab!=null)
            {
                activeCoroutine = StartCoroutine(WaitForAttackToFinish());
                //transform.rotation = quaternion.RotateY(Mathf.PI);
            }
        }
    }
    private void SetShootingPoint()
    {
        Vector2Int _halfScreenDims = new Vector2Int(Screen.width / 2, Screen.height / 2);
        Vector2 mouseDirection = new Vector2(Input.mousePosition.x - _halfScreenDims.x, Input.mousePosition.y - _halfScreenDims.y);

        bulletPositionRotation.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        bulletPositionRotation.transform.localEulerAngles = new Vector3(0, Vector3.SignedAngle(mouseDirection,Vector3.up,Vector3.forward)+110f, 0);
        head.rotation = bulletPositionRotation.rotation;
    }
    
    
    private IEnumerator WaitForAttackToFinish()
    {
        Instantiate(bulletPrefab, actualBulletPosition.position, bulletPositionRotation.rotation);
        yield return AttackTimer;
        activeCoroutine = null;
    }
}