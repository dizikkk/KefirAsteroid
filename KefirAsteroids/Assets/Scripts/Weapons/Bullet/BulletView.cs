using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BulletView : AmmoBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<PlayerView>())
            Destroy(gameObject);
    }
}