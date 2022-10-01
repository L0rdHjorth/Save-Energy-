using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    // Start is called before the first frame update
    float Tid;
    GameObject[] Flashlights;
    [SerializeField] GameObject player;
    public float speed;
    Animator anime;
    void Start()
    {
        Flashlights = GameObject.FindGameObjectsWithTag("Flashlight");
        player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.FindGameObjectWithTag("Boss") == true){
            foreach (GameObject flashlight in Flashlights)
            {
                if (Vector3.Distance(flashlight.transform.position, transform.position) <= 0.1)
                {
                    flashlight.transform.eulerAngles += new Vector3(0, 0, 90);
                }
            }
        }
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position);
        Tid += Time.deltaTime;
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (dist < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            anime.SetTrigger("walk");
        }
        else
        {
            anime.SetTrigger("state");
        }
      
        
    }
}
