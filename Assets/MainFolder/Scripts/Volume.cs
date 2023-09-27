/*		Script contains
		           ***
	                   Slider value
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider sliderValue;
    public static float VolumeAmount;

    private void Awake()
    {
        sliderValue.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Update()
    {
        sliderValue.value = VolumeAmount;
    }


}
