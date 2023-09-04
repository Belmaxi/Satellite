using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlayMusic(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Music/" + name);
        
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySound(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sound/" + name);

        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}