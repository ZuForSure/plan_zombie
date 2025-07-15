using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    public string enemy = "Enemy";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 bullet EnemySpawner allowed");
        EnemySpawner.instance = this;
    }

    public virtual void SpawnEnemyAtRandomPoint()
    {
        Transform spawnPos = PointManager.Instance.GetRandomPoint();
        Quaternion spawnRot = Quaternion.identity;

        Transform newEnemy = this.SpawnPrefab(this.enemy, spawnPos.position, spawnRot);
        newEnemy.gameObject.SetActive(true);
    }
}
