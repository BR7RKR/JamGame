using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private AudioSource audioSource;

    [SerializeField] private Transform target;
    private Rigidbody rb;
    private Vector3 direction;

    private float velocity = 3.5f;
    private float armor = 1.0f;
    private float _borderCordinate = 32;

    private void Start()
    {
        if (!GameManager2.IsGameOver)
        {
            audioSource = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    private void Update()
    {
        direction = target.position - transform.position;
        direction.Normalize();

        Vector3 lookAt = target.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
    }
    private void FixedUpdate()
    {
        if (!GameManager2.IsGameOver)
        {
            if (Input.GetMouseButtonDown(0));

            rb.MovePosition(transform.position + (direction * velocity * Time.deltaTime));
        }
    }

    private void Die()
    {
        audioSource.Play();
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
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

    public void DoBeforeDestroy()
    {
        
    }
}
