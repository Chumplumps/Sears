
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;
    [SerializeField]
    private GameObject enemy3;
    [SerializeField]
    private GameObject enemy4;

    //Commences spawning
    public void BeginSpawning()
    {
        StartCoroutine("Spawn");
    }

    //Regularly spawns enemies
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);

        SpawnEnemy();
        StartCoroutine("Spawn");
    }

    //Spawns enemies in random locations
    public GameObject SpawnEnemy()
    {
        int random = Random.Range(1, 5);
        GameObject enemy;
        switch (random)
        {
            case 1:
                enemy = Instantiate(enemy1);
                break;
            case 2:
                enemy = Instantiate(enemy2);
                break;
            case 3:
                enemy = Instantiate(enemy3);
                break;
            case 4:
                enemy = Instantiate(enemy4);
                break;
            default:
                enemy = Instantiate(enemy1);
                break;
        }

        enemy.SetActive(true);
        float xPos = Random.Range(-8.0f, 8.0f);

        enemy.transform.position = new Vector3(xPos, 7.35f, 0);

        enemies.Add(enemy);

        return enemy;
    }

    //Enemies clear when game is over
    public void ClearEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        enemies.Clear();
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
}
