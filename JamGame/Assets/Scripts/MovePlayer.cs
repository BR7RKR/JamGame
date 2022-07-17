using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovePlayer : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _borderCordinate = 32;

    [SerializeField] private Animator anim;
    
    [Tooltip("Settings")]
    public float _velocity = 10f;

    void Update()
    {
        if((_horizontalInput!=0||_verticalInput!=0) && !GameManager2.IsGameOver)
            anim.SetBool("IsMoving",true);
        else
            anim.SetBool("IsMoving",false);
    }

    void FixedUpdate()
    {
        if (!GameManager2.IsGameOver)
        {
            Move();
            KeepInBounds();
        }
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.left.normalized * _horizontalInput * _velocity * Time.deltaTime);
        transform.Translate(Vector3.back.normalized * _verticalInput * _velocity * Time.deltaTime);
    }

    private void KeepInBounds()
    {
        if (transform.position.x < -_borderCordinate)
        {
            transform.position = new Vector3(-_borderCordinate, transform.position.y, transform.position.z);
        }
        if (transform.position.x > _borderCordinate)
        {
            transform.position = new Vector3(_borderCordinate, transform.position.y, transform.position.z);
        }
        
        if (transform.position.z < -_borderCordinate)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -_borderCordinate);
        }
        if (transform.position.z > _borderCordinate)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _borderCordinate);
        }
    }
}
