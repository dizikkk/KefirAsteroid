using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AsteroidsSpawnView : MonoBehaviour
{
    public event Action onSpawnDone;
    public event Action<AsteroidView> onGetAsteroidView;
    [SerializeField] private GameObject _asteroid;
    private AsteroidView asteroidView;
    private void Start()
    {
        SpawnAsteroid(new Vector3(6f, 6f), 2f);
    }

    public void SpawnAsteroid(Vector3 positionToSpawn, float timeToSpawn)
    {
        var asteroid = Instantiate(_asteroid, positionToSpawn, Quaternion.identity);
        asteroidView = asteroid.GetComponent<AsteroidView>();
        onGetAsteroidView?.Invoke(asteroidView);
        StartCoroutine(TimerBetweenSpawn(timeToSpawn));
    }

    private IEnumerator TimerBetweenSpawn(float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);
        onSpawnDone?.Invoke();
    }
}