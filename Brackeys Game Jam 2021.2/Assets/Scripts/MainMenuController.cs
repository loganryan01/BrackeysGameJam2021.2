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

    FilmGrain filmGrain;

    private void Start()
    {
        volume.profile.TryGet<FilmGrain>(out filmGrain);
    }

    public void StartGame()
    {
        distortionEffect.enabled = true;
        filmGrain.active = true;
        StartCoroutine(Transition());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(3);

        filmGrain.active = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
