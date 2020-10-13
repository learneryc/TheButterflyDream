using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOption : MonoBehaviour
{
	public string SceneName="";
    public void ReturnToMenu() {
    	GameObject.Find("LevelLoader").
            GetComponent<LevelLoader>().MoveToNextLevel(SceneName);
    }
}
