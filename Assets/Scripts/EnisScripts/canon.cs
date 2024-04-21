using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPosition;
    
    private GameManager gameManager;
    
    private Animator animator;
    
    public Plane plane = new Plane(Vector3.forward, 0);
    
    private Vector3 dir;
    
    [SerializeField] private float bulletSpeed;
    public static int ammo;
     
     private void Start()
     {
         animator = GetComponent<Animator>();
     }

     private void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                transform.LookAt(point); 
                Fire(point);
            }
        }
        
       
        
    }
    
    private void Fire(Vector3 targetPosition)
    {
             if (ammo > 0 ) 
               {
                 dir = targetPosition - bulletPosition.position;
        
                 GameObject bullet = objectPool.instance.getPooledObject();

                   if (bullet != null)
                      { 
                         animator.SetTrigger("Shot");
                         bullet.transform.position = bulletPosition.position;
                         bullet.SetActive(true); 
                         ammo--;
                         bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed; 
                      }
                   else if (bullet == null && ammo > 0 )
                      {
                                    bullet.transform.position = bulletPosition.position;
                                    bullet.SetActive(true);
                                    ammo--;
                                    bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed; 
                      }
               }
    }

  
}
