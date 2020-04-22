using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public MouseInput inputScript;
    public RiskMeterController riskMeterScript;
    public SoldierMovement soldierMovementScript;
    public SoldierCounter soldierCountScript;
    public ClockUI clockScript;
    public GameVariables variablesScript;

    public GameObject soldierGameObject;
    public List<GameObject> soldiersList = new List<GameObject>();

    public GameObject[] popUps;
    public int popUpIndex;
    public float waitTime = 3f;
    public bool soldiersStopped = false;
    public bool soldierPickedUp = false;

    public Button medicButton;
    public GameObject wonScreen;
    public Button exitButton;
    private bool canSpawn = false;

    private void Start()
    {
        variablesScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameVariables>();
        exitButton.onClick.AddListener(ExitGame);
    }
    void ExitGame()
    {
        SceneManager.LoadScene(1);
    }
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
                canSpawn = true;
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
        else if (popUpIndex == 8)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                waitTime = 30f;
                clockScript.dayCount = 2;
                popUpIndex++;
            }
        }
        else if (popUpIndex == 9)
        {
            medicButton.enabled = false;

            if (waitTime <= 0)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.fixedDeltaTime;
            }
        }
        else if (popUpIndex == 10)
        {
            if (clockScript.upgradeSelected)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 11)
        {
            if (clockScript.upgradeOptionChosen)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 12)
        {
            riskMeterScript.currentRisk = 100;
            if (variablesScript.lives < 3)
            {
                wonScreen.SetActive(true);
                variablesScript.gameUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        if (soldiersList.Count == 0 && canSpawn)
        {
            inputScript.spawnSoldiers = true;
            inputScript.haveSoldiersSpawned = false;
            soldiersList.AddRange(GameObject.FindGameObjectsWithTag("Soldier"));
        }
        soldiersList.RemoveAll(GameObject => GameObject == null);
    }
}
