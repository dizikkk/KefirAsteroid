using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UFOView : MonoBehaviour
{
    public event Action onGetPlayerPosition;
    public event Action<UFOView> onUFODeath;

    private void Update()
    {
        onGetPlayerPosition?.Invoke();
    }

    public void Move(Vector3 playerPosition)
    {
        transform.position = transform.position + (playerPosition - transform.position).normalized * .2f * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AmmoBase>())
        {
            onUFODeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}