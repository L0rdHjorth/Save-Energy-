using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IsChildDying : MonoBehaviour
{
    [SerializeField] GameObject linkedLight;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (linkedLight.GetComponent<Light2D>().intensity == 0)
        {
            animator.SetBool("IsDead", true);
        }
    }
}
