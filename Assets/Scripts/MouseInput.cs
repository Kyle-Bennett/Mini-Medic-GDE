using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public PlayerMovement movementScript;
    public SoldierMovement soldierScript;
    public GameObject selectedMedic;
    public GameObject soldierPrefab;
    private bool haveSoldiersSpawned = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            

            if (hit)
            {
                if (hit.collider.tag == "Player")
                {
                    if (selectedMedic != null)
                    {
                        selectedMedic.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    selectedMedic = hit.collider.gameObject;
                    selectedMedic.GetComponent<SpriteRenderer>().color = Color.green;
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
                movementScript.SetTargetPosition();
                movementScript.isMoving = true;
            }
            else
            {
                movementScript.SetTargetPosition();
                movementScript.isMoving = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && haveSoldiersSpawned == false)
        {
            soldierScript = soldierPrefab.GetComponent<SoldierMovement>();
            GameObject soldierOne =  Instantiate(soldierPrefab, new Vector3(-8, -5, -1), Quaternion.identity) as GameObject;
            soldierOne.name = "soldierOne";
            GameObject soldierTwo = Instantiate(soldierPrefab, new Vector3(-6, -5, -1), Quaternion.identity) as GameObject;
            soldierTwo.name = "soldierTwo";
            GameObject soldierThree = Instantiate(soldierPrefab, new Vector3(-4, -5, -1), Quaternion.identity) as GameObject;
            soldierThree.name = "soldierThree";
            soldierScript.isSoldierMoving = true;
            haveSoldiersSpawned = true;
        }
    }
}
