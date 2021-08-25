using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatformBehaviour : MonoBehaviour
{
    public float delayTime = 5;

    private bool start = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Debug.Log("Dropping");
            transform.position -= new Vector3(0, 10, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);

        start = true;
    }
}
