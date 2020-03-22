using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [SerializeField]
    private float soldierSpeed = 125f;

    public GameObject inputManager;
    public MouseInput InputScript;
    private Vector3 soldierOneTargetPosition;
    private Vector3 soldierTwoTargetPosition;
    private Vector3 soldierThreeTargetPosition;
    private Vector3 newsoldierThreeTargetPosition;
    public bool isSoldierMoving = false;
    

    private void Start()
    {
        InputScript = inputManager.GetComponent<MouseInput>();
        soldierOneTargetPosition = new Vector3(270, 630, 0);
        soldierTwoTargetPosition = new Vector3(550, 575, 0);
        soldierThreeTargetPosition = new Vector3(1040, 350, 0);
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
            transform.position = Vector3.MoveTowards(transform.position, soldierOneTargetPosition, soldierSpeed * Time.deltaTime);
        }
        if (name == "soldierTwo")
        {
            transform.position = Vector3.MoveTowards(transform.position, soldierTwoTargetPosition, soldierSpeed * Time.deltaTime);
        }
        if (name == "soldierThree")
        {
            transform.position = Vector3.MoveTowards(transform.position, soldierThreeTargetPosition, soldierSpeed * Time.deltaTime);
        }
        if (transform.position == soldierOneTargetPosition && transform.position == soldierTwoTargetPosition && transform.position == soldierThreeTargetPosition)
        {
            isSoldierMoving = false;
        }
    }

}
