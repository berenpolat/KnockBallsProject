using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBreak : MonoBehaviour
{
    [SerializeField] private float forceMultiplier; // Kuvvet çarpanı
    private int CurrentAmmo;

    private void Update()
    {
        CurrentAmmo = Canon.ammo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("breakble"))
        {
            
            // Tetikleyici çarpışma gerçekleştiğinde çarpma noktasındaki objeyi alın
            GameObject collidedObject = other.gameObject;
            BoxCollider boxCollider = collidedObject.GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            // Çarpmanın olduğu objenin tüm çocuklarını alın
            Transform[] childTransforms = collidedObject.GetComponentsInChildren<Transform>();

            foreach (Transform child in childTransforms)
            {
                // Child objelerin rigidbody bileşenlerini alın
                Rigidbody childRigidbody = child.GetComponent<Rigidbody>();
                if (childRigidbody != null)
                {
                    // Çarpışma noktasından çocuğa doğru olan vektörü hesaplayın
                    Vector3 forceDirection = child.position - transform.position;

                    // Kuvveti uygulayın
                    childRigidbody.AddForce(forceDirection.normalized * forceMultiplier, ForceMode.Impulse);
                }
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BottomCollider"))
        {
            for (int i = 0; i < CurrentAmmo; i++)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
