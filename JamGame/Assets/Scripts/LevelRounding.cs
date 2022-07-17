using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRounding : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pos = collision.transform.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput * verticalInput != 0)
            {
                float x = Mathf.Abs(pos.x), z = Mathf.Abs(pos.z);
                
                if (Mathf.Abs(x - z) <= 0.5) 
                {
                    pos.x *= -1;
                    pos.z *= -1;
                }
                else if (x > z)
                    pos.x *= -1;
                else
                    pos.z *= -1;
            }
            else
            {
                if (horizontalInput != 0) pos.x *= -1;
                if (verticalInput != 0) pos.z *= -1;
            }
            collision.transform.position = pos;
        }
    }
}
