using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead = false;
    public float speed = 1;
    public bool canShoot = true;

    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private Transform shotSpawn;

    private float maxLeft = -8;
    private float maxRight = 8;


    //Enables the player's controls unless they're dead
    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            ShootLaser();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    //Activates the player attack
    public void ShootLaser()
    {
        StartCoroutine("Shoot");
    }

    //Triggers the laser to spawn and commences a cooldown period
    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject laserShot = SpawnLaser();
        laserShot.transform.position = shotSpawn.position;
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }

    //Spawns the laser
    public GameObject SpawnLaser()
    {
        GameObject newLaser = Instantiate(laser);
        newLaser.SetActive(true);
        return newLaser;
    }

    //Moves the player left
    public void MoveLeft()
    {
        transform.Translate(-Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, -3.22f, 0);
        }
    }

    //Moves the player right
    public void MoveRight()
    {
        transform.Translate(-Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > maxRight)
        {
             transform.position = new Vector3(maxRight, -3.22f, 0);
        }
    }

    //Kills the player
    public void Explode()
    {
        explosion.SetActive(true);
        isDead = true;
    }

    //Resets the player after death
    public void Reset()
    {
        explosion.SetActive(false);
        isDead = false;
    }
}
