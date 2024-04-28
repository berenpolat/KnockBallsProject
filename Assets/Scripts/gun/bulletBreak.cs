using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletBreak : MonoBehaviour
{
    [SerializeField] private float forceMultiplier; 
    private int CurrentAmmo;

    
    private void Update()
    {
        CurrentAmmo = Canon.ammo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("breakble"))
        {
            
            
            GameObject collidedObject = other.gameObject;
            BoxCollider boxCollider = collidedObject.GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            // Çarpmanın olduğu objenin tüm çocuklarını alın
            Transform[] childTransforms = collidedObject.GetComponentsInChildren<Transform>();

            foreach (Transform child in childTransforms)
            {
              
                Rigidbody childRigidbody = child.GetComponent<Rigidbody>();
                if (childRigidbody != null)
                {
                   
                    Vector3 forceDirection = child.position - transform.position;
                    
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
