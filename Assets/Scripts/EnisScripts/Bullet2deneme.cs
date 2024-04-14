using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Deneme : MonoBehaviour
{
    private float speed = 24f;
     
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            gameObject.SetActive(false);
        }
    }

}
