using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiskMeterController : MonoBehaviour
{
    public int maxRisk = 100;
    public int startingRisk = 0;
    public float currentRisk;
    public float riskSpeed = 5;
    public bool isSafe = true;

    public RiskMeterUI riskMeterUI;
    public MouseInput InputScript;
    public GameObject inputManagerObject;

    private void Start()
    {
        inputManagerObject = GameObject.FindGameObjectWithTag("InputManager");
        InputScript = inputManagerObject.GetComponent<MouseInput>();
        riskMeterUI.SetMaxRisk(maxRisk);
        riskMeterUI.setRisk(startingRisk);
        currentRisk = startingRisk;
    }

    private void Update()
    {
        if (isSafe)
        {
            DecreaseRisk();
        }
        else if (!isSafe)
        {
            IncreaseRisk();
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
