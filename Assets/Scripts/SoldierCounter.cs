using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierCounter : MonoBehaviour
{
    private Text savedText;
    public int soldiersSaved = 0;

    private void Start()
    {
        savedText = GetComponent<Text>();
    }

    private void Update()
    {
        savedText.text = "Soldiers Saved: " + soldiersSaved;
    }
}
