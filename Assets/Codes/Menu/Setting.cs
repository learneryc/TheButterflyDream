using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
	public AudioMixer MainVolumeMixer;
	public Slider MainVolumeSlider;
	public Slider BGMSlider;
	public Slider SoundEffectSlider;
	public int MaxVolume;

	public void Start() {
		float MainVolume = PlayerPrefs.GetFloat("MainVolume", MaxVolume);
		float BGMVolume = PlayerPrefs.GetFloat("BGMVolume", MaxVolume);
		float SoundEffectVolume = PlayerPrefs.GetFloat("SoundEffectVolume", MaxVolume);

		MainVolumeSlider.value = MainVolume;
		BGMSlider.value = BGMVolume;
		SoundEffectSlider.value = SoundEffectVolume;
	}
    public void SetMainVolume(float volume) {
    	//when toggle the slide, change corresponding volume
    	MainVolumeMixer.SetFloat("MainVolumeMixer", volume);
    	//and set to local storage
    	PlayerPrefs.SetFloat("MainVolume", volume);
    }

    public void SetBGMVolume(float volume) {
    	MainVolumeMixer.SetFloat("BGMMixer", volume);
    	PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void setSoundEffectVolume(float volume) {
    	MainVolumeMixer.SetFloat("SoundEffectMixer", volume);
    	PlayerPrefs.SetFloat("SoundEffectVolume", volume);
    }
}
