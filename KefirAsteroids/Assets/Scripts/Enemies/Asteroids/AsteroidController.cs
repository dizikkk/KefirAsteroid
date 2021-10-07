using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController
{
    public event Action<int> onAsteroidDeath;

    private List<AsteroidView> _asteroidView { get; set; }
    private SmallAsteroidController _smallAsteroidController { get; set; }


    public AsteroidController(List<AsteroidView> view, SmallAsteroidController smallAsteroidController)
    {
        _asteroidView = view;
        _smallAsteroidController = smallAsteroidController;
    }

    public void AddAsteroidView(AsteroidView view)
    {
        _asteroidView.Add(view);
        view.onDeath += AsteroidDeath;
        view.onSpawnSmallAsteroids += AddSmallAsteroidView;
    }

    public void AddSmallAsteroidView(SmallAsteroidView view)
    {
        _smallAsteroidController.AddSmallAsteroid(view);
    }

    public void AsteroidDeath(AsteroidView view)
    {
        onAsteroidDeath?.Invoke(5);
        _asteroidView.Remove(view);
    }
}