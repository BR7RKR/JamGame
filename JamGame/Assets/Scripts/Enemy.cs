using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject mesh;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private Transform target;
    
    private float velocity = 3.5f;
    private float armor = 1.0f;
    private float _borderCordinate = 32;

    private void Start()
    {
        if (!GameManager2.IsGameOver)
        {
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager2.IsGameOver)
        {
            if (Input.GetMouseButtonDown(0));

            transform.Translate(Vector3.Normalize(target.position - transform.position) * velocity * Time.deltaTime);
            mesh.transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        }
    }

    private void Die()
    {
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
