using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class newScene : MonoBehaviour
{
    [SerializeField] int antalSpace;
    // Start is called before the first frame update
    void Start()
    {
        antalSpace = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0, 0, 0));
            antalSpace += 1;
        }
        if (antalSpace==2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
