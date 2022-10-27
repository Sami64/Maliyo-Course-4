using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody enemyRb;
    public float speed=5;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var moveDirection = player.transform.position - transform.position;
        enemyRb.AddForce(moveDirection.normalized * speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
