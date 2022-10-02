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
    private Transform queen;
    private Vector2 target2;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x + rnd.Next(-5,5), player.position.y + rnd.Next(-5,5));
        queen = GameObject.FindGameObjectWithTag("Queen").transform;
        target2 = new Vector2(queen.position.x,queen.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime * rnd.Next(1,8));
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            target = target2;
            transform.position = Vector2.MoveTowards(transform.position, target2, speed * Time.deltaTime * rnd.Next(1, 8));
        }
        if (transform.position.x == target2.x && transform.position.y == target2.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
