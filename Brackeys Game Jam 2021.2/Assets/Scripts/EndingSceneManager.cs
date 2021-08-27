using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EndingSceneManager : MonoBehaviour
{
    public GameObject[] canvases;
    public float time;
    public Volume volume;

    private FilmGrain filmGrain;

    private int index = 0;
    private bool coroutineStarted = false;
    public AudioBehaviour audioBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet<FilmGrain>(out filmGrain);
        audioBehaviour = FindObjectOfType<AudioBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!coroutineStarted)
        {
            StartCoroutine(Switch());
        }
    }

    IEnumerator Switch()
    {
        coroutineStarted = true;
        
        yield return new WaitForSeconds(time);

        canvases[index].SetActive(false);
        index++;
        canvases[index].SetActive(true);

        if (index == canvases.Length - 1)
        {
            filmGrain.active = true;
            audioBehaviour.PlayVirusSound();

            yield return new WaitForSeconds(time);

            Debug.Log("Quitting");
            Application.Quit();
        }

        coroutineStarted = false;
    }
}
