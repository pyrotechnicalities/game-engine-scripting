using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void Init(AudioClip clip)
    {
        // initialize
        m_AudioSource.clip = clip;
    }

    public void Play()
    {
        m_AudioSource.Play();
    }

    private void Update()
    {
        
    }
}
