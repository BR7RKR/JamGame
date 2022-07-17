using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovePlayer : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;

    [SerializeField] private Animator anim;
    
    [Tooltip("Settings")]
    [SerializeField]private float _velocity = 10f;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_horizontalInput != 0 || _verticalInput != 0)
        {
            anim.SetBool("IsMoving", true);
            _audioSource.Play();
        }
        else
        {
            anim.SetBool("IsMoving", false);
            _audioSource.Stop();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.left.normalized * _horizontalInput * _velocity * Time.deltaTime);
        transform.Translate(Vector3.back.normalized * _verticalInput * _velocity * Time.deltaTime);
    }
}
