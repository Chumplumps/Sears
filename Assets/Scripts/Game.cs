using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score = 0;
    public bool isGameOver = false;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject startGameButton;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Spawner spawner;

    private static Game instance;

    private void Start()
    {
        instance = this;
        titleText.enabled = true;
        gameOverText.enabled = false;
        scoreText.enabled = false;
        startGameButton.SetActive(true);
    }

    public static void GameOver()
    {
        instance.titleText.enabled = true;
        instance.startGameButton.SetActive(true);
        instance.isGameOver = true;
        instance.spawner.StopSpawning();
        instance.player.GetComponent<Player>().Explode();
        instance.gameOverText.enabled = true;
    }

    public void NewGame()
    {
        isGameOver = false;
        titleText.enabled = false;
        startGameButton.SetActive(false);
        player.transform.position = new Vector3(0, -3.22f, 0);
        player.transform.eulerAngles = new Vector3(90, 180, 0);
        score = 0;
        scoreText.text = "SEARS: " + score;
        scoreText.enabled = true;
        spawner.BeginSpawning();
        player.GetComponent<Player>().Reset();
        spawner.ClearEnemies();
        gameOverText.enabled = false;
    }

    public static void EnemyDestroyed()
    {
        instance.score++;
        instance.scoreText.text = "SEARS: " + instance.score;
    }

    public Player GetPlayer()
    {
        return player.GetComponent<Player>();
    }

    public Spawner GetSpawner()
    {
        return spawner.GetComponent<Spawner>();
    }
}
