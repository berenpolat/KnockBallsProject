using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPosition;
    public Plane plane = new Plane(Vector3.forward, 0);
    private Vector3 dir;
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                transform.LookAt(point); // Kanonun hedefe bakmasını sağlar
                Fire(point);
            }
        }
    }
    
    private void Fire(Vector3 targetPosition)
    {
        dir = targetPosition - bulletPosition.position;
        
        GameObject bullet = objectPool.instance.getPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = bulletPosition.position;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed; 
        }
    }
}
