using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreasureSpawner : MonoBehaviour
{
    public Vector2 spawnAreaCenter = new(0, 6.5f);
    public Vector2 spawnAreaSize = new(17.5f, 2);

    public float meanTimeToSpawn;
    public List<GameObject> items;
    public bool active = false;

    private int _spawnedObjects = 0;
    private float _chancePerTick =>
        (float)(1.0 - Math.Pow(Math.E, Math.Log(0.5, Math.E) / (meanTimeToSpawn * (1.0 / Time.fixedDeltaTime))));

    private void FixedUpdate()
    {
        if (!active) return;
        if (!(Random.Range(0f, 1f) < _chancePerTick)) return;

        SpawnObject();
    }

    private void SpawnObject()
    {
        var obj = items[Random.Range(0, items.Count)];
        var inst = GameObject.Instantiate(obj, transform);
        inst.transform.position = GetRandomPosition();
    }

    private Vector2 GetRandomPosition() => spawnAreaCenter +
                                           new Vector2(Random.Range(-1f, 1f) * spawnAreaSize.x,
                                               Random.Range(-1f, 1f) * spawnAreaSize.y);

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(spawnAreaCenter, spawnAreaSize);
    }
}
