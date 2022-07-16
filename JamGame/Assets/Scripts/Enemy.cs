using System.Collections;

using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Target"), SerializeField] private Transform target;

    [Header("Stats")]
    [SerializeField] private float health = 5f;
    [SerializeField] private float velocity = 3.5f;
    [SerializeField] private float armor = 1.0f;
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float attackSpeed = 1.5f;
    [SerializeField] private bool canAttack = false;

    private void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.Translate(Vector3.Normalize(target.position - transform.position) * velocity * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        if (damage - armor > 0)
        {
            health -= damage;
            
            if (health <= 0)
                Destroy(gameObject);
        }
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