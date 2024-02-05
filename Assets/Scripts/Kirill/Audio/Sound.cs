using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    SFX,
    Music
}

[Serializable]
public class Sound
{
    public SoundType soundType;
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(0f, 1f)] public float settingsVolume = 1f;

    [Range(0.1f, 3f)] public float pitch = 1f;

    public bool loop;

    [HideInInspector] public AudioSource source;
}