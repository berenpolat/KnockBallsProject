using DG.Tweening;
using Entities;
using Interfaces;
using UnityEngine;

public class InstantiatorMovements : MonoBehaviour
{
    public Transform spawnPoint;
    private IFactory factory;

    private void Start()
    {
        factory = Factory.Factory.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.isGameStarted)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane*-1f; // Set the z-coordinate to the near clip plane distance
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            MyObject ball = factory.CreateObject<MyObject>(spawnPoint);
            Vector3 direction = targetPosition - spawnPoint.position;
            ball.GetComponent<Rigidbody>().AddForce(direction.normalized * 15f, ForceMode.Impulse);
        }
    }
}