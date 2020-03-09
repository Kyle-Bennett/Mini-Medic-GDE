using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public PlayerMovement movementScript;
    public GameObject selectedMedic;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                if (hit.collider.tag == "Player")
                {
                    selectedMedic = hit.collider.gameObject;
                }
                else
                {
                    selectedMedic = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && selectedMedic != null && selectedMedic.tag == "Player")
        {
            movementScript = selectedMedic.GetComponent<PlayerMovement>();
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {

                    Debug.Log("Test");
                    movementScript.SetTargetPosition();
                    movementScript.isMoving = true;

            }
            else
            {
                Debug.Log("Test");
                movementScript.SetTargetPosition();
                movementScript.isMoving = true;
            }
        }
    }
}
