using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    public AudioClip[] audioClips;
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChange;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChange;
    }

    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {
        if (state == GameManager.GameState.StartMenu)
        {
            effectSource.enabled = false;
        }
        else
        {
            effectSource.enabled = true;
        }
    }

    public void PlayEffect(AudioClip audio)
    {
        effectSource.PlayOneShot(audio);
    }

    public void ChangeMasterVolume(float vol)
    {
        AudioListener.volume = vol;
    }

    public void MusicToggle(bool val)
    {
        musicSource.mute = val;
    }

    public void EffectToggle(bool val)
    {
        effectSource.mute = val;
    }

}
