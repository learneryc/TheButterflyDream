using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenuUI;
	public float PauseButtonLength = 0.2f;

	public void Pause() {
		StartCoroutine(LoadAnimation(PauseButtonLength, true, 0f));
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

    IEnumerator LoadAnimation(float length=0.2f, bool isActive=true, float scale=0)
    {
    	yield return new WaitForSeconds(length);
    	pauseMenuUI.SetActive(isActive);
		Time.timeScale = scale;
    }
}
