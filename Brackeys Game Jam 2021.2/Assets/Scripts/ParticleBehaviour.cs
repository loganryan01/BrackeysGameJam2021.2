using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ParticleBehaviour : MonoBehaviour
{
    public float speed = 5;
    public Transform[] movingPoints;
    public Image distortionEffect;
    public Volume volume;

    FilmGrain filmGrain;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet<FilmGrain>(out filmGrain);
        Debug.Log(movingPoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingPoints.Length > 0)
        {
            if (movingPoints[index] != null)
            {
                float step = speed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, movingPoints[index].position, step);

                //Debug.Log(Vector3.Distance(transform.position, movingPoints[index].position));

                if (Vector3.Distance(transform.position, movingPoints[index].position) < 0.001f)
                {
                    
                    index++;

                    if (index == movingPoints.Length)
                    {
                        index = 0;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        distortionEffect.enabled = true;
        filmGrain.intensity.value = 1;
        filmGrain.response.value = 1;

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
