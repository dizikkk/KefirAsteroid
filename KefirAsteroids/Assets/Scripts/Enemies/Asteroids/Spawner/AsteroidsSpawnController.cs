using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawnController
{
    private AsteroidsSpawnModel _asteroidsSpawnModel { get; set; }
    private AsteroidsSpawnView _asteroidsSpawnView { get; set; }
    private AsteroidController _asteroidController { get; set; }

    public AsteroidsSpawnController(AsteroidsSpawnModel asteroidsSpawnModel, AsteroidsSpawnView asteroidsSpawnView, AsteroidController asteroidController)
    {
        _asteroidsSpawnModel = asteroidsSpawnModel;
        _asteroidsSpawnView = asteroidsSpawnView;
        _asteroidController = asteroidController;

        _asteroidsSpawnModel.onSpawn += SpawnAsteroid;
        _asteroidsSpawnView.onSpawnDone += TakeSpawnValues;
        _asteroidsSpawnView.onGetAsteroidView += AddASteroid;
    }

    private void AddASteroid(AsteroidView asteroidView)
    {
        _asteroidController.AddAsteroidView(asteroidView);
    }

    private void TakeSpawnValues()
    {
        _asteroidsSpawnModel.TakeSpawnValues();
    }

    private void SpawnAsteroid(Vector3 position, float timeToSpawn)
    {
        _asteroidsSpawnView.SpawnAsteroid(position, timeToSpawn);
    }
}