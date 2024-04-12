using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
 
   

   
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPosition;

    private void Update()
    {
   

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

   

    private void Fire()
    {
        GameObject bullet = objectPool.instance.getPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = bulletPosition.position;
            bullet.SetActive(true);
        }
    }
}
