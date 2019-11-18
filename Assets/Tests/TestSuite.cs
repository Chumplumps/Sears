using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class TestSuite
{
    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator LaserShoots()
    {
        GameObject lazer = game.GetShip().SpawnLaser();
        float initialYPos = lazer.transform.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(lazer.transform.position.y, initialYPos);
    }

    [UnityTest]
    public IEnumerator LaserDestroysFolks()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject lazer = game.GetShip().SpawnLaser();
        lazer.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator ScoreIncreases()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject lazer = game.GetShip().SpawnLaser();
        lazer.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(game.score, 1);
    }

    [UnityTest]
    public IEnumerator FolksMoveDown()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        float initialYPos = asteroid.transform.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.Less(asteroid.transform.position.y, initialYPos);
    }

    [UnityTest]
    public IEnumerator GameResets()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = game.GetShip().transform.position;
        yield return new WaitForSeconds(0.1f);

        Assert.True(game.isGameOver);
    }
}
