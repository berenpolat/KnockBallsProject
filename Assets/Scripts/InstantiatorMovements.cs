using DG.Tweening;
using Entities;
using Factory;
using Managers;
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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && GameManager.Instance.isGameStarted)
        {
            // Get the touch position in world coordinates
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition.z = Camera.main.nearClipPlane; // Set the z-coordinate to the near clip plane distance
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // Keep the y-component fixed (same as spawnPoint's y)
            targetPosition.y = spawnPoint.position.y;

            // Keep the x-component fixed (same as spawnPoint's x)
            targetPosition.x = spawnPoint.position.x;

            // Calculate the direction from spawnPoint to targetPosition
            Vector3 direction = targetPosition - spawnPoint.position;
            direction.z *= -1;
            // Create the ball and apply force
            MyObject ball = factory.CreateObject<MyObject>(spawnPoint);
            ball.GetComponent<Rigidbody>().AddForce(direction.normalized * 30f, ForceMode.Impulse);
        }
    }
}