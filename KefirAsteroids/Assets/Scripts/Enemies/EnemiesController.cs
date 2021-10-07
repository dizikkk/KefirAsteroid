using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController
{
    public event Action<int> onChangeScore;

    private UFOController _ufoController { get; set; }
    private AsteroidController _asteroidController { get; set; }
    private SmallAsteroidController _smallAsteroidController { get; set; }

    public EnemiesController(UFOController ufoController, AsteroidController asteroidController, SmallAsteroidController smallAsteroidController)
    {
        _ufoController = ufoController;
        _asteroidController = asteroidController;
        _smallAsteroidController = smallAsteroidController;

        _ufoController.onUFODeath += ChangeScore;
        _asteroidController.onAsteroidDeath += ChangeScore;
        _smallAsteroidController.onSmallAsteroidDeath += ChangeScore;
    }

    public void ChangeScore(int score)
    {
        onChangeScore?.Invoke(score);
    }
}