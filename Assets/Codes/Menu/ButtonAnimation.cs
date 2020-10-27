using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{

	public static IEnumerator LoadAnimation(float videoLength=0.1f)
    {
    	yield return new WaitForSeconds(videoLength);
    }
}
