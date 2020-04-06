using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public MouseInput inputScript;

    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime = 5f;

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
            if (inputScript.movementScript.isMoving == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (inputScript.medicsSafe == 3 && inputScript.movementScript.isMoving == false)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (waitTime <= 0)
            {
                inputScript.spawnSoldiers = true;
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 4)
        {

        }
    }
}
