using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class DistortionBehaviour : MonoBehaviour
{
    public Image distortionEffect;
    public Volume volume;
    FilmGrain filmGrain;

    private void Start()
    {
        volume.profile.TryGet<FilmGrain>(out filmGrain);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            distortionEffect.enabled = true;
            filmGrain.intensity.value = 1;
            filmGrain.response.value = 1;
        }
    }
}
