﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    private float maxY = -5;

    private void Update()
    {
        Move();
    }

    //Makes the enemy descend 
    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < maxY)
        {
            Destroy(gameObject);
        }
    }

    //Detects collision with player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            Game.GameOver();
            Destroy(gameObject);
        }
    }
}
