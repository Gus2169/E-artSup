using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExplo : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;


    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    void Update()
    {
        
    }
}
