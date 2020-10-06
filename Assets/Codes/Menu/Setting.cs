using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
	public AudioMixer MainVolumeMixer;
    public void SetVolume(float Volume) {
    	MainVolumeMixer.SetFloat("MainVolumeMixer", Volume);
    }
}
