using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    private AudioSource m_AudioSource;

    [SerializeField]
    // [Tooltip()]
    private GameObject m_SoundEffectPrefab;

    [SerializeField] private AudioClip m_Attack;
    [SerializeField] private AudioClip m_Damage;
    public enum SoundType
    {
        Attack = 1,
        Damage = 2
    }
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        instance = this;
        DontDestroyOnLoad(m_AudioSource);
    }
    public static void PlaySound(SoundType sound)
    {
        instance.PrivPlaySound(sound);
    }
    private void PrivPlaySound(SoundType sound)
    {
        AudioClip clip = null;

        switch (sound)
        {
            case SoundType.Attack: m_AudioSource.clip = m_Attack; break;
            case SoundType.Damage: m_AudioSource.clip = m_Damage; break;
        }

        GameObject newSoundEffectObject = Instantiate(m_SoundEffectPrefab);
        SoundEffect newSoundEffect = newSoundEffectObject.GetComponent<SoundEffect>();
        newSoundEffect.Init(clip);
        newSoundEffect.Play();
    }
}
