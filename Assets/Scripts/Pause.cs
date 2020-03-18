using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	
	void Start()
    {
		pauseMenuUI.SetActive(false);
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
	}

	public void PauseGame()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
