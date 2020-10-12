using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
	private static string [] LevelNumber = {"StartMenu", "LevelOne", "LevelTwo",
											"LevelThree","LevelFour", "LevelFive",
											"LevelSix","LevelSeven", "LevelEight"};

	//public Text playOption;
    public static void update() {
    	string sceneName = SceneManager.GetActiveScene().name;
    	
    	for (int i=0; i<LevelNumber.Length;i++) {
    		if (sceneName == LevelNumber[i]) {
    			sceneName = LevelNumber[i+1];
    			PlayerPrefs.SetString("SceneName", sceneName);
    			break;
    		}
    	}
    }

    public static string getScene() {
    	//string sceneName = PlayerPrefs.GetString("SceneName", "LevelOne");
		string sceneName = PlayerPrefs.GetString("SceneName");
    	return sceneName;
    }


}
