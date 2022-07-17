using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject mesh;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private Transform target;
    
    private float velocity = 3.5f;
    private float armor = 1.0f;

    private void Start()
    {
        if (!GameManager2.IsGameOver)
        {
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
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

    public void DoBeforeDestroy()
    {
        
    }
}
