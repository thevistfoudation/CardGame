using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using System;

public enum AudioIndex
{
    Shoot,
    Explosion,
    Hit
}

public class SoundsController : MonoBehaviour
{
    public static SoundsController instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        audioSource = GetComponent<AudioSource>();

    }
    private AudioSource audioSource;


    [SerializeField]
    AudioClip[] audioClips;

    public void playSound(AudioIndex index)
    {
        audioSource.PlayOneShot(audioClips[(int)index]);
    }
    public void playSound(AudioIndex index, float volumeScale)
    {
        audioSource.PlayOneShot(audioClips[(int)index], volumeScale);
    }
}

public class Sounds : SingletonMonoBehaviour<SoundsController>
{

}
