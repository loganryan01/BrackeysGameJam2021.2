using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehaviour : MonoBehaviour
{
    private AudioSource[] audioSources;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSources[1].isPlaying)
        {
            if (audioSources[1].time > 3)
            {
                audioSources[1].Stop();
            }
        }
    }

    public void PlayVirusSound()
    {
        audioSources[1].Play();
    }
}
