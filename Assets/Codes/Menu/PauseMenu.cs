using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenuUI;

	public void Pause() {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
	}

	public void Resume() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
	}

    public void Menu() {
    	Time.timeScale = 1f;
    	GameObject.Find("LevelLoader").
            GetComponent<LevelLoader>().MoveToNextLevel("StartMenu");
    }

    public void Quit() {
    	Application.Quit();
    }
}
