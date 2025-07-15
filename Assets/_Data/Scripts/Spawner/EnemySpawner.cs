using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    public static string enemy = "Enemy";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 bullet EnemySpawner allowed");
        EnemySpawner.instance = this;
    }
}
