using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel
{
    public event Action<string> onFire;
    public event Action<string> onSwitchWeaponType;
    public event Action<int> onChangeLasersCount;
    public event Action<bool> onLaserCooldown;
    public event Action<float> onLaserCooldownLeft;

    private int lasersCount = 5;

    string[] ammoName = new string[]
    {
        "Bullet",
        "Laser"
    };

    public enum WeaponType
    {
        Bullet,
        Laser
    }

    public WeaponType _weaponType;

    public void SwitchWeaponType()
    {
        if (_weaponType == WeaponType.Bullet)
            _weaponType = WeaponType.Laser;
        else
            _weaponType = WeaponType.Bullet;

        onSwitchWeaponType?.Invoke(WeaponTypeName());
    }

    public void Fire()
    {
        var type = WeaponTypeName();

        if (_weaponType == WeaponType.Laser && IsLaserReadyToShoot())
        {
            lasersCount--;
            onChangeLasersCount?.Invoke(lasersCount);
            if (lasersCount == 4)
                onLaserCooldown?.Invoke(true);
            onFire?.Invoke(type);
        }
        else if (_weaponType == WeaponType.Bullet)
            onFire?.Invoke(type);
    }

    public void ChangeLasersCount()
    {
        lasersCount++;
        onChangeLasersCount?.Invoke(lasersCount);
        if (lasersCount < 5)
            onLaserCooldown?.Invoke(true);
    }

    public void LaserCooldown()
    {
        onLaserCooldown?.Invoke(true);
    }

    public void LaserCooldownLeft(float leftTime)
    {
        onLaserCooldownLeft?.Invoke(leftTime);
    }

    public bool IsLaserReadyToShoot()
    {
        if (lasersCount == 0)
            return false;
        else return true;
    }

    public string WeaponTypeName()
    {
        if (_weaponType == WeaponType.Bullet)
            return ammoName[0];
        else
            return ammoName[1];
    }
}