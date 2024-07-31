using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;        // creating an instance variable using same class name to access script from anywhere
    public Sound[] musicSounds, SFXSounds;      //each index in this array has a variable called "sounds"
    public AudioSource musicSource, SFXSource;  //Audio source music loop enabeld

    public void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Music");
    }

    public void PlayMusic(string name)    
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if( s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
            //musicSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySFX(string name)     
    {
        Sound s = Array.Find(SFXSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            //soundsSource = s.clip;
            //soundsSource.Play();
            SFXSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
       SFXSource.mute = !SFXSource.mute; 
    }

    public void musicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;  
    }
}
