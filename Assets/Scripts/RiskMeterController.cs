using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiskMeterController : MonoBehaviour
{
    public int maxRisk = 100;
    public int startingRisk = 0;
    public float currentRisk;
    public float riskSpeed;
    public bool isSafe = true;

    public RiskMeterUI riskMeterUI;
    public MouseInput InputScript;
    public GameObject inputManagerObject;
    public GameVariables variablesScript;

    float currentTime = 0f;
    float startingTime = 3f;
    public Text countdownText;

    private void Start()
    {
        inputManagerObject = GameObject.FindGameObjectWithTag("InputManager");
        variablesScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameVariables>();
        InputScript = inputManagerObject.GetComponent<MouseInput>();
        riskMeterUI.SetMaxRisk(maxRisk);
        riskMeterUI.setRisk(startingRisk);
        currentRisk = startingRisk;
        currentTime = startingTime;

        if (variablesScript.inTutorial)
        {
            riskSpeed = 5;
        }
        else if (!variablesScript.inTutorial)
        {
            riskSpeed = 10;
        }
    }

    private void Update()
    {
        if (isSafe)
        {
            DecreaseRisk();
            currentTime = startingTime;
            countdownText.text = "";
        }
        else if (!isSafe)
        {
            IncreaseRisk();
        }

        if (currentRisk >= 100)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                Debug.Log("Destroyed");
                Destroy(gameObject);
                variablesScript.lives--;
            }
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            isSafe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            isSafe = false;
        }
    }

    void IncreaseRisk()
    {
        if (currentRisk <= maxRisk)
        {
            currentRisk += riskSpeed * Time.deltaTime;
            riskMeterUI.setRisk(currentRisk);
        }
    }
    void DecreaseRisk()
    {
        if (currentRisk >= startingRisk)
        currentRisk -= riskSpeed * Time.deltaTime;
        riskMeterUI.setRisk(currentRisk);
    }
}
