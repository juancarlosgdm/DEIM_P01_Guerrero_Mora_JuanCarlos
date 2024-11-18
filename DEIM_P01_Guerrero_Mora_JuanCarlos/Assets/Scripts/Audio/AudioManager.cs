using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Tooltip("Referencia al Audio Source de los pasos")]
    [SerializeField] private AudioSource footstepAudioSource;

    [Tooltip("Referencia al Audio Source de los objetos recogibles")]
    [SerializeField] private AudioSource objectsAudioSource;

    [Tooltip("Referencia al Audio Clip de las monedas")]
    [SerializeField] private AudioClip coinsAudioClip;

    [Tooltip("Referencia al Audio Clip de las llaves")]
    [SerializeField] private AudioClip keysAudioClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static void PlayFootstepSound()
    {
        if (!instance.footstepAudioSource.isPlaying)
        {
            instance.footstepAudioSource.pitch = Random.Range(0.9f, 1.1f);
            instance.footstepAudioSource.Play();
        }
    }

    public static void PlayCoinsSound()
    {
        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.coinsAudioClip;
            instance.objectsAudioSource.Play();
        }
    }

    public static void PlayKeysSound()
    {
        if (!instance.objectsAudioSource.isPlaying)
        {
            instance.objectsAudioSource.clip = instance.keysAudioClip;
            instance.objectsAudioSource.Play();
        }
    }
}
