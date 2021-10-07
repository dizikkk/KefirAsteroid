using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController
{
    private WeaponModel _weaponModel { get; set; }
    private WeaponView _weaponView { get; set;  }

    public WeaponController(WeaponModel model, WeaponView view)
    {
        _weaponModel = model;
        _weaponView = view;

        _weaponView.onSwitchWeapon += SwitchWeaponType;
        _weaponView.onFire += Fire;

        _weaponModel.onFire += ViewFire;

        _weaponModel.onLaserCooldown += TryLaserCooldown;
        _weaponView.onLaserCooldownDone += ChangeLasersCount;

        _weaponView.onLaserCooldownLeft += UpdateUICooldown;
    }

    private void UpdateUICooldown(float leftTime)
    {
        _weaponModel.LaserCooldownLeft(leftTime);
    }

    private void ChangeLasersCount()
    {
        _weaponModel.ChangeLasersCount();
    }

    private void TryLaserCooldown(bool isLaserCooldown)
    {
        _weaponView.TryCooldownLaser(isLaserCooldown);
    }

    private void SwitchWeaponType()
    {
        _weaponModel.SwitchWeaponType();
    }

    private void Fire()
    {
        _weaponModel.Fire();
    }

    private void ViewFire(string weaponType)
    {
        _weaponView.Fire(weaponType);
    }
}