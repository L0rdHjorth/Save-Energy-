using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class MoveController : MonoBehaviour
{
    private CircleCollider2D circleCollider;

    [SerializeField] float speed;
    private Vector3 moveDelta;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector3(x, y, 0)*speed;
        // reset move delta

        // swap sprite direction i retningen den går

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        


    }
}
