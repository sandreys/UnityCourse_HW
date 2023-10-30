using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip fireAudioClip;
    public AudioClip reloadAudioClip;
    public AudioClip walkingAudioClip;
    public AudioClip landAudioClip;


    public AudioSource fireAudioSource;
    public AudioSource reloadAudioSource;
    public AudioSource walkAudioSource;
    public AudioSource landAudioSource;

    private bool _isPlayingSound;
    public void Start()
    {
        fireAudioSource = spawnAudioSource(fireAudioClip);
        reloadAudioSource = spawnAudioSource(reloadAudioClip);
        walkAudioSource = spawnAudioSource(walkingAudioClip);
        landAudioSource = spawnAudioSource(landAudioClip);
    }
    public void FireSound()
    {
        if (fireAudioSource.isPlaying)
            fireAudioSource.Stop();
        fireAudioSource.Play();
    }

    public void WalkSound()
    {
        if (walkAudioSource.isPlaying == false)
        {
           
        }


    }

    public void ReloadSound()
    {
        if (reloadAudioSource.isPlaying)
            reloadAudioSource.Stop();
        reloadAudioSource.Play();
    }

    public void LandSound()
    {
        if (landAudioSource.isPlaying)
            landAudioSource.Stop();
        landAudioSource.Play();
    }

    public IEnumerator MoveSound()
    {
        if (_isPlayingSound == false)
        {
            _isPlayingSound = true;
            walkAudioSource.Play();

            yield return new WaitForSeconds(walkingAudioClip.length);

            _isPlayingSound = false;
        }


    }


    private AudioSource spawnAudioSource(AudioClip clip)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.loop = false;
        source.playOnAwake = false;

        return source;
    }

}
