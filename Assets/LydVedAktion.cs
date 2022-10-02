using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LydVedAktion : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource source;
    [SerializeField] GameObject linkedLight;
    bool hasSpoken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSpoken)
        {
            if (linkedLight.GetComponent<Light2D>().intensity == 0)
            {
                source.PlayOneShot(clip);
                hasSpoken = true;

            }
        }

    }
}
