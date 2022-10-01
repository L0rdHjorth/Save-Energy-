using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class sounds : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioSource source;
    public bool hasPlayed = false;
    void Start()
    {
        source.PlayOneShot(clip);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayed)
        {
            if (Time.time > 10f)
            {
                source.PlayOneShot(clip2);
                hasPlayed = true;
            }
        }
        
    }
}
