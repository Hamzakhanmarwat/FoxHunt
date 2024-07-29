using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _SFXSlider;

    private void Update()
    {
        //When game starts or scene changes sets
        //slider value to previously set slider value
        //across scenes 

        _musicSlider.value = AudioManager.Instance.musicSource.volume;
        _SFXSlider.value = AudioManager.Instance.SFXSource.volume;

    }


    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic(); 
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.musicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_SFXSlider.value);
    }
}
