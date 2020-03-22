using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 75;

    public GameObject inputManager;
    public MouseInput InputScript;
    private Vector3 soldierOneTargetPosition;
    private Vector3 soldierTwoTargetPosition;
    private Vector3 soldierThreeTargetPosition;
    public bool isSoldierMoving = false;
    

    private void Start()
    {
        InputScript = inputManager.GetComponent<MouseInput>();
        soldierOneTargetPosition = new Vector3(-6, 1, -1);
        soldierTwoTargetPosition = new Vector3(0, 2, -1);
        soldierThreeTargetPosition = new Vector3(2, 4, -1);
    }
    void Update()
    {
        if (isSoldierMoving)
        {
            soldierMove();
        }
    }

    void soldierMove()
    {
        if (name == "soldierOne")
        {
            transform.position = Vector3.MoveTowards(transform.position, soldierOneTargetPosition, speed * Time.deltaTime);
        }
        if (name == "soldierTwo")
        {
            transform.position = Vector3.MoveTowards(transform.position, soldierTwoTargetPosition, speed * Time.deltaTime);
        }
        if (name == "soldierThree")
        {
            transform.position = Vector3.MoveTowards(transform.position, soldierThreeTargetPosition, speed * Time.deltaTime);
        }
        if (transform.position == soldierOneTargetPosition)
        {
            isSoldierMoving = false;
            
        }
    }

}
