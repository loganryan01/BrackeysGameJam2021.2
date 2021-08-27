using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Image distortionEffect;
    public Volume volume;
    public GameObject mainMenuCanvas;
    public GameObject optionsScreen;
    private AudioBehaviour audioBehaviour;

    FilmGrain filmGrain;

    private void Start()
    {
        audioBehaviour = FindObjectOfType<AudioBehaviour>();
        volume.profile.TryGet<FilmGrain>(out filmGrain);
    }

    public void StartGame()
    {
        audioBehaviour.PlayVirusSound();
        distortionEffect.enabled = true;
        filmGrain.active = true;
        StartCoroutine(Transition());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        optionsScreen.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(3);

        filmGrain.active = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
