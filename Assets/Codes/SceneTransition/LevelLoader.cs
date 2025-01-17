﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public Animator transition;
	public string sceneName="";
    public string trigger = "";
	public float transitionTime = 1f;
	public float videoLength = 0f;

    public bool saveScene = true;
	
    
    void Start()
    {
        StartCoroutine(LoadLevel());
        if (saveScene) PersistentData.update();
    }

    public void MoveToNextLevel(string nextScene)
    {
        if (nextScene == "") return;
        sceneName = nextScene;
        trigger = "Crossfade";
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
    	yield return new WaitForSeconds(videoLength);

        //change scene to another one
    	if (trigger!="") {
    		transition.SetTrigger(trigger);
			yield return new WaitForSeconds(transitionTime);
			if (sceneName!="") SceneManager.LoadScene(sceneName);
		}
    	
    }
}
