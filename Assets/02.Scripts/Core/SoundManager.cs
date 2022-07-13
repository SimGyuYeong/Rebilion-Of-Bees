using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private List<Slider> volumeSliderList = new List<Slider>();
    [SerializeField]
    private List<string> parameterNameList = new List<string>();

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            float volume = PlayerPrefs.GetFloat($"{parameterNameList[i]}");
            volumeSliderList[i].value = volume;
            VolumeChange(i);
        }
    }

    public void VolumeChange(int idx)
    {
        audioMixer.SetFloat(parameterNameList[idx],
            (volumeSliderList[idx].value <= volumeSliderList[idx].minValue) ? -80f : volumeSliderList[idx].value);
        VolumeSave(idx);
    }

    public void VolumeSave(int idx)
    {
        PlayerPrefs.SetFloat($"{parameterNameList[idx]}", volumeSliderList[idx].value);
    }
}
