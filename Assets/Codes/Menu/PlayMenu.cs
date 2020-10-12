using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{

	public Animator transition;
	public string trigger = "";
	public float transitionTime = 1f;

	public Button NewGame;
	public Button Resume;
	private string SceneName = "";

	public void Start() {
		SceneName = PersistentData.getScene();
		//if(SceneName == "LevelOne")
		if (SceneName == "Begining")
			Resume.gameObject.SetActive(false);
	}

	public void PlayNewGame() {
		SceneName = "Begining";
		PersistentData.update();
		//SceneName = "LevelOne";
		PlayGame();
	}

	public void PlayGame() {
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel() {
		if (trigger!="") {
			transition.SetTrigger(trigger);
			yield return new WaitForSeconds(transitionTime);
			if (SceneName != "") SceneManager.LoadScene(SceneName);
		}

		
	}

	public void QuitGame() {
		Application.Quit();
	}
    
}