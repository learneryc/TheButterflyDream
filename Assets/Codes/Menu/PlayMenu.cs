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
	public float animationTime = 0.2f;

	public Button NewGame;
	public Button Resume;
	private string SceneName = "";

	public void Start() {
		SceneName = PersistentData.getScene();
		if (SceneName == "PreLevelOne") {
			Resume.gameObject.SetActive(false);
		}
		
	}

	public void PlayNewGame() {
		SceneName = "PreLevelOne";
		PersistentData.setMagic1(0);
		PersistentData.setMagic2(0);
		PersistentData.setMagic3(0);
		PlayGame();
	}

	public void PlayGame() {
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel() {
		if (trigger!="") {
			yield return new WaitForSeconds(animationTime);
			transition.SetTrigger(trigger);
			yield return new WaitForSeconds(transitionTime);
			if (SceneName != "") SceneManager.LoadScene(SceneName);
		}

		
	}

	
    
}