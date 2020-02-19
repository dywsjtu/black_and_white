using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;

    public AudioSource star;

    public AudioSource red;
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

    public void PlayStar()
    {
        if (!star.isPlaying) 
        {
            star.Play();
        }
    }

    public void PlayRed()
    {
        if (!red.isPlaying) 
        {
            red.Play();
        }
    }
}
