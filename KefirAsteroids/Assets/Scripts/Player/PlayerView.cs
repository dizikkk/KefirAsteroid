using UnityEngine.InputSystem;
using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public event Action<float> onRotate;
    public event Action<float> onRotateAngle;
    public event Action<float> onMoveForward;
    public event Action onDeath;
    public event Action<Vector3> onGetPlayerPosition;
    public event Action<float> onGetPlayerSpeed;

    private Vector2 cameraBoundsX;
    private Vector2 cameraBoundsY;

    private float cameraBoundXmin;
    private float cameraBoundXmax;
    private float cameraBoundYmin;
    private float cameraBoundYmax;

    private float speed = 0f;
    private float _rotateAngle;
    private float _moveAccelerator;

    public void OnRotate(InputAction.CallbackContext callbackContext)
    {
        var rotateValue = callbackContext.ReadValue<float>();
        if (Time.deltaTime > 0)
            onRotate?.Invoke(rotateValue);
    }

    public void OnMoveForward(InputAction.CallbackContext callbackContext)
    {
        var moveForwardValue = callbackContext.ReadValue<float>();
        if (Time.deltaTime > 0)
            onMoveForward?.Invoke(moveForwardValue);
    }

    private void Start()
    {
        GetBounds();
    }

    private void Update()
    {
        if (_rotateAngle != 0)
            PlayerRotate();

        PlayerMove();

        PlayerPosition();
    }

    public void ChangedRotateAngle(float calculatedRotateValue)
    {
        _rotateAngle = calculatedRotateValue;
    }

    public void PlayerRotate()
    {
        var rotateAngle = transform.eulerAngles.z;
        transform.Rotate(0f, 0f, _rotateAngle * Time.deltaTime, Space.Self);
        onRotateAngle?.Invoke(rotateAngle);
    }

    public void ChangeAcceleratorValue(float calcultedMoveValue)
    {
        _moveAccelerator = calcultedMoveValue;
    }

    public void PlayerMove()
    {
        if (_moveAccelerator > 0)
        {
            if (speed <= 4f)
                speed += Time.deltaTime;
        }
        else
        {
            if (speed > 0f)
                speed -= Time.deltaTime;
        }
        
        Vector3 movement = Vector3.up;
        transform.Translate(movement * speed * Time.deltaTime);
        onGetPlayerSpeed?.Invoke(speed);

        CheckBounds();
    }

    private void GetBounds()
    {
        cameraBoundsY = new Vector2(Camera.main.orthographicSize, -Camera.main.orthographicSize);
        cameraBoundsX = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, -Camera.main.orthographicSize * Camera.main.aspect);
        cameraBoundXmax = cameraBoundsX.x;
        cameraBoundXmin = cameraBoundsX.y;
        cameraBoundYmax = cameraBoundsY.x;
        cameraBoundYmin = cameraBoundsY.y;
    }

    private void CheckBounds()
    {
        if (transform.position.x > cameraBoundXmax)
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        else if (transform.position.x < cameraBoundXmin)
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        if (transform.position.y > cameraBoundYmax)
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        else if (transform.position.y < cameraBoundYmin)
            transform.position = new Vector2(transform.position.x, -transform.position.y);
    }

    public Vector3 PlayerPosition()
    {
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        onGetPlayerPosition?.Invoke(playerPosition);
        return playerPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onDeath?.Invoke();
    }
}