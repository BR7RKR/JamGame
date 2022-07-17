using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    void Start()
    {
        Vector3 direction = Random.insideUnitSphere * 1.5f;
        direction.y = Mathf.Abs(direction.y) * 2;
        transform.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
        transform.GetComponent<Rigidbody>().AddTorque(direction * 1.5f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}