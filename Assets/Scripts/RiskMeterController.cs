using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiskMeterController : MonoBehaviour
{
    public int maxRisk = 100;
    public int startingRisk = 0;
    public float currentRisk;
    public float riskSpeed = 5;

    public RiskMeterUI riskMeterUI;
    public MouseInput InputScript;

    private void Start()
    {
        riskMeterUI.SetMaxRisk(maxRisk);
        riskMeterUI.setRisk(startingRisk);
        currentRisk = startingRisk;
        Debug.Log(currentRisk);
    }

    private void Update()
    {
        if (InputScript.medicsSafe == 3)
        {
            DecreaseRisk();
        }
        else if (InputScript.medicsSafe < 3)
        {
            IncreaseRisk();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            Debug.Log("Safe");
            InputScript.medicsSafe++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            Debug.Log("Not Safe");
            InputScript.medicsSafe--;
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
