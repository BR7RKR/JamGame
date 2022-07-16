using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject mesh;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private Transform target;

    private float health = 5f;
    private float velocity = 3.5f;
    private float armor = 1.0f;
    private float damage = 1.0f;
    private float attackSpeed = 1.5f;
    private bool canAttack = false;

    private void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) TakeDamage(3f);

        transform.Translate(Vector3.Normalize(target.position - transform.position) * velocity * Time.deltaTime);
        mesh.transform.rotation = Quaternion.LookRotation(target.position - transform.position);
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