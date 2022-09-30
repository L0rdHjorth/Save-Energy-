using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveController : MonoBehaviour
{
    private CircleCollider2D circleCollider;

    [SerializeField] float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.magnitude);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector3(x, y, 0)*speed;
        // reset move delta

        // swap sprite direction i retningen den går

        if (x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // sluk lys funktion
        if (Input.GetKeyDown(KeyCode.Space))
        {
            slukLys();
        }
    }

    public void slukLys()
    {
        GameObject[] lysArray = GameObject.FindGameObjectsWithTag("Lys"); // Alt lys bliver sat ind i lysArray
        foreach (GameObject lys in lysArray)
        {
            if (Vector3.Distance(lys.transform.position, transform.position) <= 1f) // lyset slukket hvis spilleren er tæt nok på
            {
                lys.GetComponent<Light2D>().intensity = 0;
            }
        }

    }

}
