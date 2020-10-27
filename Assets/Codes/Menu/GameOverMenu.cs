using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	public void LoadLevel() {
		string scene = PlayerPrefs.GetString("SceneName");
		GameObject.Find("LevelLoader").
            GetComponent<LevelLoader>().MoveToNextLevel(scene);
	}

	public void LoadMenu() {
		GameObject.Find("LevelLoader").
            GetComponent<LevelLoader>().MoveToNextLevel("StartMenu");
	}
    
}