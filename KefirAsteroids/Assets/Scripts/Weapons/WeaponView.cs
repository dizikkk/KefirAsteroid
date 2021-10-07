using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private InputActionReference _switchActionReference;
    [SerializeField] private InputActionReference _fireActionReference;

    public event Action<float> onLaserCooldownLeft;
    public event Action onLaserCooldownDone;
    public event Action onSwitchWeapon;
    public event Action onFire;

    [SerializeField] private List<GameObject> _prefabsToShoot;

    private float _timeToCooldown = 3f;
    private bool _isLaserCooldown;

    private void Update()
    {
        if (_isLaserCooldown)
            LaserCooldown();
    }

    public void OnFire(InputAction.CallbackContext callbackContext)
    {
        var value = callbackContext.ReadValue<float>();
        if (value == 1)
            onFire?.Invoke();
    }

    public void OnSwitch(InputAction.CallbackContext callbackContext)
    {
            onSwitchWeapon?.Invoke();
    }

    public void Fire(string weaponType)
    {
        var value = transform.eulerAngles;
        var ammo = Instantiate(_prefabsToShoot.Find(x => x.name == weaponType), transform.position, Quaternion.Euler(value));
    }

    public void TryCooldownLaser(bool isCooldown)
    {
        _isLaserCooldown = isCooldown;
    }

    public void LaserCooldown()
    {
        if (_timeToCooldown > 0)
        {
            _timeToCooldown -= Time.deltaTime;
            onLaserCooldownLeft?.Invoke(_timeToCooldown);
        }

        if (_timeToCooldown <= 0)
        {
            _timeToCooldown = 3f;
            _isLaserCooldown = false;
            onLaserCooldownDone?.Invoke();
            onLaserCooldownLeft?.Invoke(_timeToCooldown);
        }
    }
}