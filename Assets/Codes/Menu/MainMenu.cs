using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string SceneName="";
	public Animator transition;
	public string trigger = "";
	public float transitionTime = 1f;

	public void PlayGame() {
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel() {
		if (trigger!="") {
			transition.SetTrigger(trigger);
			yield return new WaitForSeconds(transitionTime);
		}
		if (SceneName != "") SceneManager.LoadScene(SceneName);
	}

	public void QuitGame() {
		Application.Quit();
	}
    
}