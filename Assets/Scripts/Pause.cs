using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{

	public static bool GameIsPaused = false;
	//public Text stat_text;
	public TMP_Text stat_text;
	public GameObject pauseMenuUI;
	public ClockUI upgrades;

	
	void Start()
    {
		pauseMenuUI.SetActive(false);
		stat_text.enabled = false;
		
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{

			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				PauseGame();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		stat_text.enabled = false;
	}

	public void PauseGame()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		stat_text.enabled = true;
		stat_text.text = "+ upgrade player speed " + upgrades.playerSpeedPercent + "%\n\n" + "- risk meter takes longer to fill by " + upgrades.riskMeterPercent + "%\n\n" + "+ soldiers take longer to bleed out by " + upgrades.bleedoutPercent + "%\n\n" + "+ increases last chance by  " + upgrades.countdownSeconds + " seconds";

	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
