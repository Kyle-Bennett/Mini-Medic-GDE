using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Transform riskMeter;
    private Vector3 targetPosition;
    public bool isMoving = false;
    public bool isCarrying = false;

    public Vector3 transformComp;
    public Vector3 targetComp;
    public GameVariables variablesScript;

    private void Start()
    {
        variablesScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameVariables>();
    }

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
        targetComp = targetPosition;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, variablesScript.playerSpeed * Time.deltaTime);
        transformComp = transform.position;
        float dist = Vector3.Distance(targetPosition, transform.position);

        if (dist <= 1)
        {
            isMoving = false;
        }
    }

}
