using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreasureSpawner : MonoBehaviour
{
    public Vector2 spawnAreaCenter = new(0, 6.5f);
    public Vector2 spawnAreaSize = new(17.5f, 2);
    public float meanTimeToSpawn;
    public float minSpawnDelay;
    public List<GameObject> items;
    public List<int> weights;
    public bool active = false;

    private int _summedweights
    {
        get
        {
            var s = 0;
            for (var i = 0; i < items.Count; i++)
                s += weights[i];
            return s;
        }
    }
    private float _chancePerTick =>
        (float)(1.0 - Math.Pow(Math.E, Math.Log(0.5, Math.E) / (meanTimeToSpawn * (1.0 / Time.fixedDeltaTime))));

    private float spawnDelay = 0f;

    private void Start()
    {
        for (int i = weights.Count; i < items.Count; i++)
            weights.Add(1);
    }

    private void FixedUpdate()
    {
        if (!active) return;
        if (!(Random.Range(0f, 1f) < _chancePerTick)) return;

        if (spawnDelay <= 0)
        {
            SpawnObject();
            spawnDelay = minSpawnDelay;
        }
        else
            spawnDelay -= Time.fixedDeltaTime;
    }

    private void SpawnObject()
    {
        var w = Random.Range(0, _summedweights);
        var i = 0;
        for (; i < items.Count; i++)
        {
            w -= weights[i];
            if (w < 0)
                break;
        }
        var obj = items[i];
        var inst = GameObject.Instantiate(obj, transform);
        inst.transform.position = GetRandomPosition();
    }

    private Vector2 GetRandomPosition() => spawnAreaCenter +
                                           new Vector2(Random.Range(-1f, 1f) * spawnAreaSize.x,
                                               Random.Range(-1f, 1f) * spawnAreaSize.y);

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(spawnAreaCenter, spawnAreaSize * 2);
    }
}
