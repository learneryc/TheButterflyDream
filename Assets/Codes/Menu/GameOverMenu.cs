using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	public string SceneName="";
	public Animator transition;
	public string trigger = "";
	public float transitionTime = 1f;

	public void Restart() {
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
		SceneName="StartMenu";
		StartCoroutine(LoadLevel());
	}
    
}