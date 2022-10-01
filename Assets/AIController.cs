using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    float Tid;
    [SerializeField] float AISpeed;
    GameObject[] Flashlights;
    // Start is called before the first frame update
    void Start()
    {
        Flashlights = GameObject.FindGameObjectsWithTag("Flashlight");
        if (tag == "VerticalAI")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1f * AISpeed, 0);
        }
        else if (tag == "HorizontalAI")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-1f * AISpeed, 0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Tid += Time.deltaTime;
        if (Tid >= 4)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity*-1;
            Tid = 0f;
            foreach (GameObject flashlight in Flashlights)
            {
                if (Vector3.Distance(flashlight.transform.position,transform.position) <= 0.2)
                {
                    flashlight.transform.eulerAngles += new Vector3(0, 0, 180);
                }
            }
        }
 
        
    }
}
