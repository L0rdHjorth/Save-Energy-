using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using static Unity.VisualScripting.Member;

public class MoveController : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    public int lysSlukket; //antal lys slukket
    public GameObject[] lysArray;
    public GameObject[] kontaktArray;
    public int lightsInKontakter = 0;
   
    [SerializeField] float speed;
    bool canExit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        lysArray = GameObject.FindGameObjectsWithTag("Lys"); // Alt lys bliver sat ind i lysArray 
        circleCollider = GetComponent<CircleCollider2D>();
        lysSlukket = 0;
        print(lightsInKontakter);
        print(kontaktArray.Length);
        print(lysArray.Length);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("XSpeed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Flashlight")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ExitDoor")
        {
            if (canExit)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void slukLys()
    {
        GameObject[] lysArray = GameObject.FindGameObjectsWithTag("Lys"); // Alt lys bliver sat ind i lysArray 
        GameObject[] kontaktArray = GameObject.FindGameObjectsWithTag("Kontakt");
        GameObject[] kontakterMedFlereLys = GameObject.FindGameObjectsWithTag("KontaktMedFlereLys");

        foreach (GameObject lys in lysArray)
        {
            if (Vector3.Distance(lys.transform.position, transform.position) <= 1f) // lyset slukket hvis spilleren er tæt nok på
            {
                if (lys.GetComponent<Light2D>().intensity != 0)
                {
                    lysSlukket++;
                }
                lys.GetComponent<Light2D>().intensity = 0;
            }
        }
        foreach (GameObject kontakt in kontaktArray)
        {
            if (Vector3.Distance(kontakt.transform.position, transform.position) <= 1f)
            {
                if (kontakt.GetComponent<Kontakt>().linkedLight.GetComponent<Light2D>().intensity != 0)
                {
                    lysSlukket++;
                }
                kontakt.GetComponent<Kontakt>().linkedLight.GetComponent<Light2D>().intensity = 0;
            }
        }
        foreach (GameObject kontaktMedFlereLys in kontakterMedFlereLys)
        {
            if (Vector3.Distance(kontaktMedFlereLys.transform.position, transform.position) <= 1f)
            {
                kontaktMedFlereLys.GetComponent<KontaktFlereLys>().SlukAlleLys();
            }
        }
        if (lysArray.Length + kontaktArray.Length + lightsInKontakter == lysSlukket)
        {
            canExit = true;
        }

    }//slukLys end 
}
