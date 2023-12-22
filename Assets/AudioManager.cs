using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundtracks;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Play a random track on start
        PlayRandomTrack();
    }

    void Update()
    {
        // Check if the current track has finished playing
        if (!audioSource.isPlaying)
        {
            PlayRandomTrack();
        }
    }

    void PlayRandomTrack()
    {
        // Choose a random track from the array
        int randomIndex = Random.Range(0, soundtracks.Length);

        // Play the randomly selected soundtrack
        audioSource.clip = soundtracks[randomIndex];
        audioSource.Play();
    }
}
