using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    private Rigidbody rb;
    private bool isBroken = false;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       rb.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isBroken)
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            isBroken = true;
        }
    }
    
   
}
