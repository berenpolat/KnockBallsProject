using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Deneme : MonoBehaviour
{
    private float speed = 24f;

    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
