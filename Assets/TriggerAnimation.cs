using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    Animator Desk;
    void Start()
    {
        Desk = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animationstart();
        }
        
    }

    public void animationstart()
    {
        Desk.SetInteger("state", 1);
    }
}
