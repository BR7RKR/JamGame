using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float seconds;

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        Destroy(gameObject,seconds);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            Destroy(gameObject);
    }
}