using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TriggerAnimationRow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    public GameObject[] deskarray;
    Animator Deskanimation;
    [SerializeField] GameObject linkedLight;
    void Start()
    {
        Deskanimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            deskanimationstart();
        }
        deskanimationstart();

    }

    public void deskanimationstart()
    {
        GameObject[] deskarray = GameObject.FindGameObjectsWithTag("Desk");


        foreach (GameObject Desk in deskarray)
        {
            if (linkedLight.GetComponent<Light2D>().intensity == 0)
            {
                Deskanimation.SetInteger("state", 1);
            }
        }
    }
}
