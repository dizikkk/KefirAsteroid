using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController
{
    public event Action<int> onUFODeath;

    private UFOModel _ufoModel { get; set; }
    private List<UFOView> _ufoView { get; set; }
    private PlayerController _playerController { get; set; }

    public UFOController(UFOModel model, List<UFOView> view, PlayerController playerController)
    {
        _ufoModel = model;
        _ufoView = view;
        _playerController = playerController;
    }

    public void AddUFOView(UFOView view)
    {
        _ufoView.Add(view);
        view.onUFODeath += UFODeath;
    }

    public void UFODeath(UFOView view)
    {
        _ufoView.Remove(view);
        onUFODeath?.Invoke(10);
    }

    public void MoveUFO()
    {
        var playerPosition = _playerController.GetPlayerPosition();
        foreach (var item in _ufoView)
        {
            if (item != null)
                item.Move(playerPosition);
        }
    }
}