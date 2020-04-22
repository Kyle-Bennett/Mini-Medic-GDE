using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{


	public void Quit()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void levelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void loadGame()
	{
		SceneManager.LoadScene("Tutorial");
	}

	public void loadAchievements()
	{
		SceneManager.LoadScene("Achievements");
	}


}
