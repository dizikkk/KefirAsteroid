using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidsSpawnModel
{
    public event Action<Vector3,float> onSpawn;

    private Vector2 cameraBoundsX;
    private Vector2 cameraBoundsY;

    private float cameraBoundXmin;
    private float cameraBoundXmax;
    private float cameraBoundYmin;
    private float cameraBoundYmax;

    private void GetBounds()
    {
        cameraBoundsY = new Vector2(Camera.main.orthographicSize, -Camera.main.orthographicSize);
        cameraBoundsX = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, -Camera.main.orthographicSize * Camera.main.aspect);
        cameraBoundXmax = cameraBoundsX.x;
        cameraBoundXmin = cameraBoundsX.y;
        cameraBoundYmax = cameraBoundsY.x;
        cameraBoundYmin = cameraBoundsY.y;
    }

    public void TakeSpawnValues()
    {
        GetBounds();
        onSpawn?.Invoke(PositionToSpawn(), TimeToSpawn());
    }

    private float TimeToSpawn()
    {
        var timeToSpawn = UnityEngine.Random.Range(1f, 5f);
        return timeToSpawn;
    }

    private Vector3 PositionToSpawn()
    {
        var position = new Vector3(UnityEngine.Random.Range(cameraBoundXmin, cameraBoundXmax),
                                   UnityEngine.Random.Range(cameraBoundYmin, cameraBoundYmax), 0f);
        return position;
    }
}