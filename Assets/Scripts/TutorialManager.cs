using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public MouseInput inputScript;
    public RiskMeterController riskMeterScript;
    public SoldierMovement soldierMovementScript;
    public SoldierCounter soldierCountScript;
    public GameObject soldierGameObject;
    public List<GameObject> soldiersList = new List<GameObject>();

    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime = 3f;
    public bool soldiersStopped = false;
    public bool soldierPickedUp = false;

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (inputScript.selectedMedic != null)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (inputScript.movementScript.isMoving == true && inputScript.selectedMedic.GetComponent<RiskMeterController>().isSafe == false)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            
            if (inputScript.selectedMedic.GetComponent<RiskMeterController>().isSafe == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                inputScript.spawnSoldiers = true;
                popUpIndex++;
                waitTime = 7f;
            }
        }
        else if (popUpIndex == 4)
        {
            soldierGameObject = GameObject.FindGameObjectWithTag("Soldier");
            soldierMovementScript = soldierGameObject.GetComponent<SoldierMovement>();
            if (soldiersList.Count < 3)
            {
                soldiersList.AddRange(GameObject.FindGameObjectsWithTag("Soldier"));
            }

            foreach (GameObject sold in soldiersList)
            {
                if (sold.GetComponent<SoldierMovement>().isSoldierMoving == true)
                {
                    soldiersStopped = false;
                }
                else if (sold.GetComponent<SoldierMovement>().isSoldierMoving == false)
                {
                    soldiersStopped = true;
                }
            }
            if (soldiersStopped == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 6)
        {
            foreach (GameObject sold in soldiersList)
            {
                if (sold.GetComponent<SoldierMovement>().hasJoint == true)
                {
                    soldierPickedUp = true;
                }
            }

            if (soldierPickedUp == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 7)
        {
            if (soldierCountScript.soldiersSaved == 1)
            {
                popUpIndex++;
            }
        }
    }
}
