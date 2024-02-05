using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.pitch = sound.pitch;
            sound.source.volume = sound.volume * sound.settingsVolume;
            sound.source.loop = sound.loop;
        }
    }
    
    private Sound FindSound(string soundName)
    {
        return Array.Find(sounds, s => s.name == soundName);
    }
    
    public void Play(string soundName)
    {
        Sound sound = FindSound(soundName);
        if (sound == null)
            return;
        
        sound.source.Play();
    }
    
    public bool IsPlaying(string soundName)
    {
        Sound sound = FindSound(soundName);
        if (sound == null)
            return false;
        
        return sound.source.isPlaying;
    }
    
    public void Stop(string soundName)
    {
        Sound sound = FindSound(soundName);
        if (sound == null)
            return;
        
        sound.source.Stop();
    }
    
    public void StopAll()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }
    
    public void StopAllSoundType(SoundType soundType)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.soundType == soundType)
                sound.source.Stop();
        }
    }
    
    public void VolumeAll(float volume, SoundType soundType)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.soundType == soundType)
                sound.source.volume = volume * sound.settingsVolume;
        }
    }
    
    public float GetSoundVolume(string soundName)
    {
        Sound sound = FindSound(soundName);
        if (sound == null)
            return 0;
        
        return sound.source.volume;
    }
    
    public void ChangeSoundVolume(string soundName, float volume)
    {
        Sound sound = FindSound(soundName);
        if (sound == null)
            return;
        
        sound.source.volume = volume * sound.settingsVolume;
    }
    
    public float GetSoundPitch(string soundName)
    {
        Sound sound = FindSound(soundName);
        if (sound == null)
            return 0;
        
        return sound.source.pitch;
    }
    
    public void ChangeSoundPitch(string soundName, float pitch)
    {
        Sound sound = FindSound(soundName);
        if (sound == null)
            return;
        
        sound.source.pitch = pitch;
    }
}
