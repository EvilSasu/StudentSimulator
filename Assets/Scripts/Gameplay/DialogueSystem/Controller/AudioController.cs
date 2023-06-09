using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundSource;
    public AudioClip sceneMusic;


    private AudioVolume audioVolume = null;
    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("AudioVolume"))
            audioVolume = GameObject.FindGameObjectWithTag("AudioVolume").GetComponent<AudioVolume>();
        if (audioVolume != null)
        {
            musicSource.volume = audioVolume.audioVolume;
            soundSource.volume = audioVolume.audioVolume;
        }
        else
        {
            musicSource.volume = 0.5f;
            soundSource.volume = 0.5f;
        }

        if (sceneMusic != null)
        {
            musicSource.clip = sceneMusic;
            musicSource.Play();
        }
    }

    private void OnDestroy()
    {
        if(sceneMusic != null)
            musicSource.Stop();
    }

    public void PlayAudio(AudioClip music, AudioClip sound)
    {
        if(sound != null)
        {
            soundSource.clip = sound;
            soundSource.Play();
        }

        if(music != null && musicSource.clip != music)
        {
            StartCoroutine(SwitchMusic(music));
        }
    }

    private IEnumerator SwitchMusic(AudioClip music)
    {
        if(musicSource.clip != null)
        {
            while(musicSource.volume > 0)
            {
                musicSource.volume -= 0.05f;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            musicSource.volume = 0;
        }

        musicSource.clip = music;
        musicSource.Play();

        while(musicSource.volume < 0.5)
        {
            musicSource.volume += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
