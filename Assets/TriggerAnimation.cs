using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TriggerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Player;
    public GameObject[] deskarray;
    Animator Deskanime;
    void Start()
    {
        Deskanime = GetComponent<Animator>();
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
        GameObject[] deskarray = GameObject.FindGameObjectsWithTag("Desk");


        foreach (GameObject Desk in deskarray)
        {
            if (Vector3.Distance(Desk.transform.position,Player.transform.position) <= 1f)
            {
                Deskanime.SetInteger("state", 1);


            }
        }
    }
}
