using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public float clickTime = 0.17f;

	public void SwitchtoMenu(GameObject menu) {
		StartCoroutine(waitSwitch(menu));
	}
	

    public void QuitGame() {
    	StartCoroutine(waitQuit());
	}

	IEnumerator waitSwitch(GameObject menu) {
		yield return new WaitForSeconds(clickTime);
		gameObject.SetActive(false);
		menu.SetActive(true);
	}

	IEnumerator waitQuit() {
		yield return new WaitForSeconds(clickTime);
		Application.Quit();
	}
}
