using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UIModel
{
    public event Action<string> onChangePlayerCoordinates;
    public event Action<float> onChangePlayerSpeed;
    public event Action<float> onChangePlayerAngle;
    public event Action<int> onChangeCountLasers;
    public event Action<float> onChangeLaserTimer;
    public event Action<string> onChangeWeaponType;

    public void ChangePlayerCoordinates(string coordinates)
    {
        onChangePlayerCoordinates?.Invoke(coordinates);
    }

    public void ChangePlayerSpeed(float speed)
    {
        onChangePlayerSpeed?.Invoke(speed);
    }

    public void ChangePlayerAngle(float angle)
    {
        onChangePlayerAngle?.Invoke(angle);
    }

    public void ChangeCountLasers(int count)
    {
        onChangeCountLasers?.Invoke(count);
    }

    public void ChangeLaserTimer(float time)
    {
        onChangeLaserTimer?.Invoke(time);
    }

    public void ChangeWeapontype(string type)
    {
        onChangeWeaponType?.Invoke(type);
    }
}
