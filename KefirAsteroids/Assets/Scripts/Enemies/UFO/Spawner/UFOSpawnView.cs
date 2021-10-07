using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UFOSpawnView : MonoBehaviour
{
    public event Action onSpawnDone;
    public event Action<UFOView> onGetUFOView;
    [SerializeField] private GameObject _ufo;
    private UFOView ufoView;

    private void Start()
    {
        SpawnUFO(new Vector3(6f, 6f), 2f);
    }

    public void SpawnUFO(Vector3 positionToSpawn, float timeToSpawn)
    {
        var ufo = Instantiate(_ufo, positionToSpawn, Quaternion.identity);
        ufoView = ufo.GetComponent<UFOView>();
        onGetUFOView?.Invoke(ufoView);
        StartCoroutine(TimerBetweenSpawn(timeToSpawn));
    }

    private IEnumerator TimerBetweenSpawn(float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);
        onSpawnDone?.Invoke();
    }
}