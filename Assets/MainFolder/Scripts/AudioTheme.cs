/*		Script contains
		           ***
	            Music value saving
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTheme : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    void Start()
    {
        AudioSource.Play();
        AudioSource.volume = PlayerPrefs.GetFloat("Volume");

    }

    // Update is called once per frame


    public void updateVolume (float volume)
    {
        AudioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        Volume.VolumeAmount = volume;
    }
}
