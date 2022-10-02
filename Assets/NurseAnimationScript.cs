using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseAnimationScript : MonoBehaviour
{
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity != new Vector2(0,0))
        {
            animator.SetBool("IsMoving", true);
        }
    }
}
