using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    public Transform[] platformPoints;
    public float speed;

    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platformPoints.Length > 0)
        {
            if (platformPoints[index] != null)
            {
                float step = speed * Time.deltaTime;
                
                transform.position = Vector3.MoveTowards(transform.position, platformPoints[index].position, step);

                if (Vector3.Distance(transform.position, platformPoints[index].position) < 0.001f)
                {
                    index++;

                    if (index == platformPoints.Length)
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
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
