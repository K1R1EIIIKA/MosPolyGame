using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Music,
    SFX
}

[Serializable]
public class Sound
{
    public SoundType soundType;
    public string name;
    public AudioClip clip;
    
    [Range(0f, 1f)]
    public float volume;
    public float settingsVolume;

    public bool loop;
    
    [HideInInspector]
    public AudioSource source;
}
