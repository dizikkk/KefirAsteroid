using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawnController
{
    private UFOSpawnModel _ufoSpawnModel { get; set; }
    private UFOSpawnView _ufoSpawnView { get; set; }
    private UFOController _ufoController { get; set; }

    public UFOSpawnController(UFOSpawnModel ufoSpawnModel, UFOSpawnView ufoSpawnView, UFOController ufoController)
    {
        _ufoSpawnModel = ufoSpawnModel;
        _ufoSpawnView = ufoSpawnView;
        _ufoController = ufoController;

        _ufoSpawnModel.onSpawn += SpawnUFO;
        _ufoSpawnView.onSpawnDone += TakeSpawnValues;

        _ufoSpawnView.onGetUFOView += AddUFOView;
    }

    private void AddUFOView(UFOView ufoView)
    {
        ufoView.onGetPlayerPosition += _ufoController.MoveUFO;
        _ufoController.AddUFOView(ufoView);
    }

    private void TakeSpawnValues()
    {
        _ufoSpawnModel.TakeSpawnValues();
    }
    
    private void SpawnUFO(Vector3 position, float timeToSpawn)
    {
        _ufoSpawnView.SpawnUFO(position, timeToSpawn);
    }
}