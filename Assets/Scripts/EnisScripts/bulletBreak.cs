using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBreak : MonoBehaviour
{
    public GameObject spawnPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("breakble"))
        {
            // Çarpma gerçekleştiğinde çarpma noktasındaki objeyi alın
            GameObject collidedObject = collision.gameObject;

            // Çarpmanın olduğu objenin tüm çocuklarını alın
            Transform[] childTransforms = collidedObject.GetComponentsInChildren<Transform>();

            // Her bir çocuk için işlem yapın
            foreach (Transform childTransform in childTransforms)
            {
                
                    // Aktif durumu true yapın
                    childTransform.gameObject.SetActive(false);
                
            }
        }
    }
}
