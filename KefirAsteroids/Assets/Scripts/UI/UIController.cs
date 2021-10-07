using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{
    private UIModel _uiModel { get; set; }
    private UIView _UIView { get; set; }
    private WeaponModel _weaponModel { get; set; }
    private PlayerController _playerController { get; set; }
    private EnemiesController _enemesController { get; set; }

    public UIController(UIModel model, UIView view, WeaponModel weaponModel, PlayerController playerController, EnemiesController enemiesController)
    {
        _uiModel = model;
        _UIView = view;
        _weaponModel = weaponModel;
        _playerController = playerController;
        _enemesController = enemiesController;

        _weaponModel.onChangeLasersCount += ChangeCountLasers;
        _weaponModel.onSwitchWeaponType += ChangeWeapontype;
        _weaponModel.onLaserCooldownLeft += ChangeLaserTimer;

        _playerController.onPlayerDeath += ShowDeathUI;
        _playerController.onGetPlayerSpeed += ChangePlayerSpeed;
        _playerController.onGetRotateAngle += ChangePlayerAngle;
        _playerController.onGetPlayerPosition += ChangePlayerCoordinates;

        _enemesController.onChangeScore += ChangeScore;
    }

    private void ChangePlayerCoordinates(Vector3 coordinates)
    {
        _UIView.SetPlayerCoordinates(coordinates);
    }

    private void ChangePlayerSpeed(float speed)
    {
        _UIView.SetPlayerSpeed(speed);
    }

    private void ChangePlayerAngle(float angle)
    {
        _UIView.SetPlayerAngle(angle);
    }

    private void ChangeCountLasers(int count)
    {
        _UIView.SetCountLasers(count);
    }

    private void ChangeLaserTimer(float time)
    {
        _UIView.SetLaserTimer(time);
    }

    private void ChangeWeapontype(string type)
    {
        _UIView.SetWeapontype(type);
    }

    private void ChangeScore(int score)
    {
        _UIView.ChangeScore(score);
    }

    private void ShowDeathUI()
    {
        _UIView.ShowRestartButton();
    }
}
