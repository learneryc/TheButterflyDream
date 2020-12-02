using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenuUI;
    public GameObject optionMenu;
    public GameObject pauseMenu;
    public GameObject pauseButton;
	public float PauseButtonLength = 0.2f;
    public int clickFrames = 10;

    private bool resume = false;
    private bool option = false;
    private bool back  = false;
    private int frameCounter = 0;

    void Update() {
        if (resume) {
            if (frameCounter == clickFrames) {
                resume = false;
                Time.timeScale = 1f;
                pauseMenuUI.SetActive(false);
            }
            frameCounter++;
        }

        if (option) {
            if (frameCounter == clickFrames) {
                option = false;
                pauseMenu.SetActive(false);
                optionMenu.SetActive(true);
            }
            frameCounter++;
        }

        if (back) {
            if (frameCounter == clickFrames) {
                back = false;
                optionMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }
            frameCounter++;
        }


    }

	public void Pause() {
		StartCoroutine(LoadAnimation(pauseMenuUI, PauseButtonLength, true, 0f));
	}

	public void Resume() {
        resume = true;
        frameCounter = 0;
	}

    public void Option() {
        option = true;
        frameCounter = 0;
    }

    public void Back() {
        back = true;
        frameCounter = 0;
    }

    public void Menu() {
    	Time.timeScale = 1f;
        pauseButton.SetActive(false);
    	GameObject.Find("LevelLoader").
            GetComponent<LevelLoader>().MoveToNextLevel("StartMenu");
    }


    IEnumerator LoadAnimation(GameObject menu, float length=0.2f, bool isActive=true, float scale=0)
    {
    	yield return new WaitForSeconds(length);
    	menu.SetActive(isActive);
		Time.timeScale = scale;
    }
}
