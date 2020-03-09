using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 4;

    private Vector3 targetPosition;
    public bool isMoving = false;

    void Update()
    {
        
        if (isMoving)
        {
            Move();
        }
    }

    public void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
    
}
