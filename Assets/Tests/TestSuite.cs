﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class TestSuite
{
    private Game game;

    //Commences test
    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    //Concludes test
    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    //Tests to see if laser shoots
    [UnityTest]
    public IEnumerator LaserShoots()
    {
        GameObject lazer = game.GetPlayer().SpawnLaser();
        float initialYPos = lazer.transform.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(lazer.transform.position.y, initialYPos);
    }

    //Tests to see if laser destroys enemies
    [UnityTest]
    public IEnumerator LaserDestroysEnemies()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject lazer = game.GetPlayer().SpawnLaser();
        lazer.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    //Tests to see if score increases when enemies are destroyed
    [UnityTest]
    public IEnumerator ScoreIncreases()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject lazer = game.GetPlayer().SpawnLaser();
        lazer.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(game.score, 1);
    }

    //Tests to see if enemies descend
    [UnityTest]
    public IEnumerator EnemiesMoveDown()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        float initialYPos = asteroid.transform.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.Less(asteroid.transform.position.y, initialYPos);
    }

    //Tests to see if game resets
    [UnityTest]
    public IEnumerator GameResets()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = game.GetPlayer().transform.position;
        yield return new WaitForSeconds(0.1f);

        Assert.True(game.isGameOver);
    }
}
