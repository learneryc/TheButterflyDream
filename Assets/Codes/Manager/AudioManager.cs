using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) {
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    } 

    // Play the music in Resource folder and set the volume
    public void Play(string _audio, double volume = 0.2) {
        var audioClip = Resources.Load<AudioClip>(_audio);
        
        audioSource.PlayOneShot(audioClip, (float)volume);
    }

    // IEnumerator playSoundWithDelay(AudioClip clip, float volume, int delay) {
    //     yield return new WaitForSeconds(delay);
    //     audioSource.PlayOneShot(clip, volume);
    // }
}
