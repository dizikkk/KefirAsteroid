using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AsteroidView : AsteroidBase
{
    public event Action<AsteroidView> onDeath;
    public event Action<SmallAsteroidView> onSpawnSmallAsteroids;
    [SerializeField] private GameObject _smallAsteroid;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AmmoBase>())
        {
            onDeath?.Invoke(this);
            SpawnSmallAsteroid();
            Destroy(gameObject);
        }
    }

    private void SpawnSmallAsteroid()
    {
        for (int i = 0; i < 3; i++)
        {
            var smallAsteroid = Instantiate(_smallAsteroid, transform.position, Quaternion.identity);
            onSpawnSmallAsteroids?.Invoke(smallAsteroid.GetComponent<SmallAsteroidView>());
        }
    }
}