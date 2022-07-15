using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovePlayer : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    
    [Tooltip("Settings")]
    [SerializeField]private float _velocity = 10f;
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right.normalized * _horizontalInput * _velocity * Time.deltaTime);
        transform.Translate(Vector3.forward.normalized * _verticalInput * _velocity * Time.deltaTime);
    }
}
