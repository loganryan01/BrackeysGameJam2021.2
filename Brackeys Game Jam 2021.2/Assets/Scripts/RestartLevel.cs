using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public Image distortionEffect;
    public Volume volume;

    FilmGrain filmGrain;
    public AudioBehaviour audioBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet<FilmGrain>(out filmGrain);
        audioBehaviour = FindObjectOfType<AudioBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            distortionEffect.enabled = true;
            filmGrain.active = true;

            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        audioBehaviour.PlayVirusSound();

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
