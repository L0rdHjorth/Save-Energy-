using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorLock : MonoBehaviour
{
    bool DoorsAreUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().mass = 10000000;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<MoveController>().canExit)
        {
            this.GetComponent<Rigidbody2D>().mass = 1;
        }
    }
}
