using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    public AudioSource soundEffectSource;
    public AudioClip success;
    public AudioClip play;
    public AudioClip force;
    public AudioClip velocity;
    public AudioClip gravity;
    public AudioClip click;
    public List<AudioClip> keyClips = new List<AudioClip>();

    private int keyClipIndex = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySuccessClip()
    {
        soundEffectSource.PlayOneShot(success);
    }

    public void PlayPlayClip()
    {
        soundEffectSource.PlayOneShot(play);
    }

    public void PlayVelocityClip()
    {
        soundEffectSource.PlayOneShot(velocity);
    }

    public void PlayForceClip()
    {
        soundEffectSource.PlayOneShot(force);
    }

    public void PlayGravityClip()
    {
        soundEffectSource.PlayOneShot(gravity);
    }

    public void PlayClickClip()
    {
        soundEffectSource.PlayOneShot(click);
    }

    public void PlayKeyClip()
    {
        soundEffectSource.PlayOneShot(keyClips[keyClipIndex]);
        keyClipIndex++;
        if (keyClipIndex > 2)
        {
            keyClipIndex = 0;
        }
    }
}