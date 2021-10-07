using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SmallAsteroidView : MonoBehaviour
{
    public event Action<SmallAsteroidView> onDeath;

    private Vector3 movement;
    private void Start()
    {
        movement = Direction();
    }

    private Vector3 Direction()
    {
        float x = UnityEngine.Random.Range(-360f, 360f);
        float y = UnityEngine.Random.Range(-360f, 360f);
        Vector3 direction = new Vector3(x, y, 0f);
        return direction;
    }

    private void Update()
    {
        transform.Translate(movement * .004f * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AmmoBase>())
        {
            onDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
