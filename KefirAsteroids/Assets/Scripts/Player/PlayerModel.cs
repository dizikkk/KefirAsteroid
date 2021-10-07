using UnityEngine;
using System;

public class PlayerModel
{
    public event Action<float> onRotate;
    public event Action<float> onMoveForward;
    public event Action onGetPlayerPosition;
    public event Action onDeath;

    public event Action onFire;

    public void CalculateRotate(float rotateValue)
    {
        var calculatedRotateValue = rotateValue * -100f;
        onRotate?.Invoke(calculatedRotateValue);
    }

    public void CalculateMove(float moveForwardValue)
    {
        onMoveForward?.Invoke(moveForwardValue);
    }

    public void GetPlayerPosition()
    {
        onGetPlayerPosition?.Invoke();
    }

    public void PlayerDeath()
    {
        Time.timeScale = 0;
        onDeath?.Invoke();
    }
}