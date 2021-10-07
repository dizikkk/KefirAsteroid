using System.Collections.Generic;
using UnityEngine;
using System;

public class SmallAsteroidController
{
    public event Action<int> onSmallAsteroidDeath;

    private List<SmallAsteroidView> _smallAsteroidView { get; set; }

    public SmallAsteroidController(List<SmallAsteroidView> view)
    {
        _smallAsteroidView = view;
    }

    public void AddSmallAsteroid(SmallAsteroidView view)
    {
        _smallAsteroidView.Add(view);
        view.onDeath += SmallAsteroidDeath;
    }

    public void SmallAsteroidDeath(SmallAsteroidView view)
    {
        onSmallAsteroidDeath?.Invoke(2);
        _smallAsteroidView.Remove(view);
    }
}