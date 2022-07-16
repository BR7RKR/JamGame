using System.Collections;

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [Header("Target"), SerializeField] private Transform target;

    [Header("Stats")]
    [SerializeField] private float health = 5f;
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float armor = 1.0f;
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float attackSpeed = 1.5f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = speed;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
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
        NavMeshAgent TAgent = target.GetComponent<NavMeshAgent>();

        while (target != null &&
            (Vector2.Distance(target.position, agent.transform.position) - (agent.radius + TAgent.radius)) <= 0.5f)
        {
            Debug.Log("Минус " + damage + "хп.");
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            StartCoroutine(Attack());
        }
    }
}