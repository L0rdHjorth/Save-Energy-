using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class MoveController : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    int lysSlukket; //antal lys slukket

    [SerializeField] float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        print("hello world");
        circleCollider = GetComponent<CircleCollider2D>();
        lysSlukket = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("XSpeed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
       GetComponent<Animator>().SetFloat("YSpeed",Mathf.Abs( GetComponent<Rigidbody2D>().velocity.y));

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
                print(lysArray.Length);
                if (lys.GetComponent<Light2D>().intensity != 0)
                {
                    lysSlukket++;

                }
                lys.GetComponent<Light2D>().intensity = 0;
            }
            if (lysArray.Length == lysSlukket)
            {
                GameOver();
                print("lys end");
            }
        }

    }//slukLys end 
    public void GameOver()
    {
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
        print("END");
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
