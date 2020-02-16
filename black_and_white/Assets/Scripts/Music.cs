using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Play()
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.Play();
        }
       
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    // public void PlayBlack()
    // {
    //     if (!black.isPlaying) 
    //     {
    //         black.Play();
    //     }
    // }

    // public void PlayWhite()
    // {
    //     if (!white.isPlaying) 
    //     {
    //         white.Play();
    //     }
    // }
}
