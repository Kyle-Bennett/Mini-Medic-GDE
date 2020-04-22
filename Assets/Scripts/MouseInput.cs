using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public PlayerMovement movementScript;
    public SoldierMovement soldierScript;
    public GameObject selectedMedic;
    public GameObject soldierPrefab;
    public Canvas canvas;
    public bool haveSoldiersSpawned = false;
    public bool spawnSoldiers = false;
    public int medicsSafe = 0;
    public GameObject upgradePanel;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && upgradePanel.activeInHierarchy == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


            if (hit)
            {
                if (hit.collider.tag == "Player")
                {
                    if (selectedMedic != null)
                    {
                        selectedMedic.GetComponentInChildren<ParticleSystem>().Stop();
                    }
                    selectedMedic = hit.collider.gameObject;
                    selectedMedic.GetComponentInChildren<ParticleSystem>().Play();
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

        if ((spawnSoldiers == true && haveSoldiersSpawned == false))
        {
            soldierScript = soldierPrefab.GetComponentInChildren<SoldierMovement>();

            GameObject soldierOne = Instantiate(soldierPrefab, new Vector3(150, 150, 0), Quaternion.identity) as GameObject;
            soldierOne.name = "soldierOne";
            soldierOne.transform.parent = canvas.transform;

            GameObject soldierTwo = Instantiate(soldierPrefab, new Vector3(200, 150, 0), Quaternion.identity) as GameObject;
            soldierTwo.name = "soldierTwo";
            soldierTwo.transform.parent = canvas.transform;

            GameObject soldierThree = Instantiate(soldierPrefab, new Vector3(325, 150, 0), Quaternion.identity) as GameObject;
            soldierThree.name = "soldierThree";
            soldierThree.transform.parent = canvas.transform;

            soldierScript.isSoldierMoving = true;
            haveSoldiersSpawned = true;
        }
    }

    public void spawnAllies()
    {



        soldierScript = soldierPrefab.GetComponentInChildren<SoldierMovement>();

        GameObject soldierOne = Instantiate(soldierPrefab, new Vector3(Random.Range(-100, 1500), 100, 0), Quaternion.identity) as GameObject;
        soldierOne.name = "soldierOne";
        soldierOne.transform.parent = canvas.transform;

        GameObject soldierTwo = Instantiate(soldierPrefab, new Vector3(Random.Range(-100, 1500), 100, 0), Quaternion.identity) as GameObject;
        soldierTwo.name = "soldierTwo";
        soldierTwo.transform.parent = canvas.transform;

        GameObject soldierThree = Instantiate(soldierPrefab, new Vector3(Random.Range(-100, 1500), 100, 0), Quaternion.identity) as GameObject;
        soldierThree.name = "soldierThree";
        soldierThree.transform.parent = canvas.transform;

        soldierScript.isSoldierMoving = true;
    }
}