using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBagMovement : MonoBehaviour
{
    // An object that has the same x-axis as the mouse cursor. Y and z positions are fixed.
    // No speed, just a position.
    // Should not go out of bounds (use the camera to calculate the bounds)

    [SerializeField] float swingAmount = 30f;
    [SerializeField] float rotationSpeed = 5f;

    private float minX;
    private float maxX;

    private Vector3 previousPosition;
    private float previousDeltaX;


    private void Awake()
    {
        CalculateBounds();
    }

    private void CalculateBounds()
    {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

        minX = leftEdge.x;
        maxX = rightEdge.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(worldPosition.x, minX, maxX);

        float deltaX = newPosition.x - previousPosition.x;

        // Swing the bag based on the change in X position
        if (Mathf.Abs(deltaX) > 0.01f)
        {
            previousDeltaX = deltaX;
        }
        else
        {
            deltaX = previousDeltaX;
        }

        float targetRotationZ = -swingAmount * deltaX;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetRotationZ);

        transform.position = newPosition;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        previousPosition = newPosition;
    }


}