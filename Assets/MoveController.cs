using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
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
        GetComponent<Animator>().SetFloat("XSpeed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        // GetComponent<Animator>().SetFloat("YSpeed2", GetComponent<Rigidbody2D>().velocity.y);
        
//GetComponent<Animator>().SetFloat("YSpeed", GetComponent<Rigidbody2D>().velocity.y);
        //GetComponent<Animator>().SetFloat("YSpeed2", GetComponent<Rigidbody2D>().velocity.y);




        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector3(x, y, 0)*speed;

        if (y < 0)
        {
            GetComponent<Animator>().SetFloat("YSpeed",Mathf.Abs( GetComponent<Rigidbody2D>().velocity.y));
            GetComponent<Animator>().SetFloat("YSpeed2", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y * 0));

        }
        else if (y > 0)
        {
            GetComponent<Animator>().SetFloat("YSpeed2", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y));
            GetComponent<Animator>().SetFloat("YSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y * 0));

        }
        else
        {
            GetComponent<Animator>().SetFloat("YSpeed2", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y * 0));
            GetComponent<Animator>().SetFloat("YSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y * 0));

        }









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
            if (Vector3.Distance(lys.transform.position, transform.position) <= 0.5f) // lyset slukket hvis spilleren er t�t nok p�
            {
                lys.GetComponent<Light2D>().intensity = 0;
            }
        }

    }

}
