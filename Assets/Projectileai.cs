using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Projectileai : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

   public System.Random rnd = new System.Random(); 
    private Transform player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime * rnd.Next(1,8));
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
