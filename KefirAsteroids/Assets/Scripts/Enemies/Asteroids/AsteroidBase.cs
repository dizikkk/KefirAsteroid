using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBase : MonoBehaviour
{
    private Vector3 movement;
    private void Start()
    {
        movement = Direction();
    }

    private Vector3 Direction()
    {
        float x = Random.Range(-360f, 360f);
        float y = Random.Range(-360f, 360f);
        Vector3 direction = new Vector3(x, y, 0f);
        return direction;
    }

    private void Update()
    {
        transform.Translate(movement * .002f * Time.deltaTime);
    }
}