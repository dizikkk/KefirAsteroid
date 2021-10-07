using System;
using UnityEngine;

public class PlayerController
{
    public event Action onPlayerDeath;
    public event Action<float> onMove;
    public event Action<float> onRotate;
    public event Action<float> onGetRotateAngle;
    public event Action<float> onGetPlayerSpeed;
    public event Action<Vector3> onGetPlayerPosition;

    private PlayerView _playerView { get; set; }
    private PlayerModel _playerModel { get; set; }

    public PlayerController(PlayerView view, PlayerModel model)
    {
        _playerView = view;
        _playerModel = model;

        _playerView.onMoveForward += CalculateMoveForward;
        _playerView.onRotate += CalculateRotate;
        _playerView.onRotateAngle += GetRotateAngle;

        _playerModel.onRotate += PlayerRotate;
        _playerModel.onMoveForward += PlayerMoveForward;

        _playerView.onGetPlayerPosition += GetPlayerPosition;

        _playerView.onGetPlayerSpeed += GetPlayerSpeed;

        _playerView.onDeath += PlayerDeath;
    }
    
    private void GetPlayerSpeed(float speed)
    {
        onGetPlayerSpeed?.Invoke(speed);
    }

    private void GetRotateAngle(float angle)
    {
        onGetRotateAngle?.Invoke(angle);
    }

    private void GetPlayerPosition(Vector3 position)
    {
        onGetPlayerPosition?.Invoke(position);
    }

    public Vector3 GetPlayerPosition()
    {
        return _playerView.PlayerPosition();
    }

    private void CalculateRotate(float rotateValue)
    {
        _playerModel.CalculateRotate(rotateValue);
        onRotate?.Invoke(rotateValue);
    }

    private void CalculateMoveForward(float moveValue)
    {
       _playerModel.CalculateMove(moveValue);
        onMove?.Invoke(moveValue);
    }

    private void PlayerRotate(float calculatedRotateValue)
    {
        _playerView.ChangedRotateAngle(calculatedRotateValue);
    }

    private void PlayerMoveForward(float moveValue)
    {
        _playerView.ChangeAcceleratorValue(moveValue);
    }

    private void PlayerDeath()
    {
        onPlayerDeath?.Invoke();
    }
}