using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
	public AudioMixer MainVolumeMixer;
	public Slider MainVolumeSlider;

	public void Start() {
		float volume = PlayerPrefs.GetFloat("MainVolume", 0);
		MainVolumeSlider.value = volume;
	}
    public void SetVolume(float volume) {
    	MainVolumeMixer.SetFloat("MainVolumeMixer", volume);
    	PlayerPrefs.SetFloat("MainVolume", volume);
    }
}
