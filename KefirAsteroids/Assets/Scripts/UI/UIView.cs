using System.Collections;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIView : MonoBehaviour
{
    public event Action onGetPlayerPosition;

    [SerializeField] private TextMeshProUGUI _playerCoordinates;
    [SerializeField] private TextMeshProUGUI _playerSpeed;
    [SerializeField] private TextMeshProUGUI _playerAngle;
    [SerializeField] private TextMeshProUGUI _laserCount;
    [SerializeField] private TextMeshProUGUI _laserTimer;
    [SerializeField] private TextMeshProUGUI _weaponType;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _lose;
    [SerializeField] private Button _restartButton;

    private int currentScore = 0;

    private void Update()
    {
        onGetPlayerPosition?.Invoke();
    }

    private void Start()
    {
        _restartButton.onClick.AddListener(HideRestartButton);
        _lose.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
    }

    public void SetPlayerCoordinates(Vector3 coordinates)
    {
        string mainText = "Координаты: ";
        _playerCoordinates.text = mainText;
        _playerCoordinates.text += coordinates;
    }

    public void SetPlayerSpeed(float speed)
    {
        speed = (float)Math.Round(speed, 2);
        string mainText = "Скорость: ";
        _playerSpeed.text = mainText;
        _playerSpeed.text += speed;
    }

    public void SetPlayerAngle(float angle)
    {
        angle = (float)Math.Round(angle, 0);
        string mainText = "Угол поворота: ";
        _playerAngle.text = mainText;
        _playerAngle.text += angle;
    }

    public void SetCountLasers(int count)
    {
        string mainText = "Количество зарядов лазера: ";
        _laserCount.text = mainText;
        _laserCount.text += count;
    }

    public void SetLaserTimer(float time)
    {
        time = (float)System.Math.Round(time, 2);
        string mainText = "Перезарядка лазера: ";
        _laserTimer.text = mainText;
        _laserTimer.text += time;
    }

    public void SetWeapontype(string type)
    {
        string mainText = "Тип оружия: ";
        _weaponType.text = mainText;
        _weaponType.text += type;
    }

    public void ChangeScore(int score)
    {
        currentScore += score;
        string mainText = "Ваш счёт: ";
        _score.text = mainText;
        _score.text += currentScore;
    }

    public void ShowRestartButton()
    {
        Time.timeScale = 0;
        _restartButton.gameObject.SetActive(true);
        _score.gameObject.SetActive(true);
        _restartButton.onClick.AddListener(HideRestartButton);
    }

    private void HideRestartButton()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}