using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private AudioSource audioSource;

    [SerializeField] private Transform target;
    private Rigidbody rb;
    private Vector3 direction;

    private float health = 5f;
    private float velocity = 3.5f;
    private float armor = 1.0f;
    private float damage = 1.0f;
    private float attackSpeed = 1.5f;
    private bool canAttack = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
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
        rb.MovePosition(transform.position + (direction * velocity * Time.deltaTime));
    }

    public void TakeDamage(float damage)
    {
        if (damage - armor > 0)
        {
            health -= damage - armor;

            if (health <= 0)
                Die();
        }
    }

    private void Die()
    {
        audioSource.Play();
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator Attack()
    {
        while (canAttack && target != null)
        {
            Debug.Log("Минус " + damage + "хп.");
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            canAttack = true;
            StartCoroutine(Attack());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canAttack = false;
        }
    }
}