﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;

	void Update ()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 5);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Game.EnemyDestroyed();
            Destroy(gameObject);
            FindObjectOfType<Spawner>().enemies.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
