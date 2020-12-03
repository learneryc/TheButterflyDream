using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentData : MonoBehaviour
{
	//public Text playOption;
    public static void update() {
    	string sceneName = SceneManager.GetActiveScene().name;
    	PlayerPrefs.SetString("SceneName", sceneName);
    }

    public static string getScene() {
    	string sceneName = PlayerPrefs.GetString("SceneName", "PreLevelOne");
    	return sceneName;
    }

	// Magic part 
	private static int magic1 = 0;
	private static int magic2 = 0;
	private static int magic3 = 0;

	public static void setMagic1(int val){
		magic1 = val;
		PlayerPrefs.SetInt("Magic1", val);
	}
	public static  int getMagic1(){
		return PlayerPrefs.GetInt("Magic1", 0);
	}

	public static void setMagic2(int val){
		magic2 = val;
		PlayerPrefs.SetInt("Magic2", val);
	}
	public static  int getMagic2(){
		return PlayerPrefs.GetInt("Magic2", 0);
	}

	public static void setMagic3(int val){
		magic3 = val;
		PlayerPrefs.SetInt("Magic3", val);
	}
	public static  int getMagic3(){
		return PlayerPrefs.GetInt("Magic3", 0);
	}


}
