using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Shooting : PlantAbstract
{
    [Header("Shooting")]
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1f;

    private void FixedUpdate()
    {
        this.Shoot();
    }

    protected virtual void Shoot()
    {
        if (!this.plantCtrl.PlantFindEnemy.IsFindEnemy) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0f;

        //Transform newBullet = BulletManager.Instance.SpawnPrefab(this.GetBulletName(), spawnPos, Quaternion.identity);
        //if (newBullet == null) return;
        //newBullet.gameObject.SetActive(true);

        Vector3 spawnPos = transform.position;
        GameObject newBullet = SpawnAbleObj.Instance.GetPrefabByName("Bullet");
        LeanPool.Spawn(newBullet, spawnPos, Quaternion.identity);
    }
}
