using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider audioSlider;
    public GameObject mainMenuCanvas;
    public GameObject optionsCanvas;
    public AudioMixer audioMixer;

    public void BackButton()
    {
        mainMenuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }

    public void AudioChange()
    {
        audioMixer.SetFloat("Volume", audioSlider.value);
    }
}
