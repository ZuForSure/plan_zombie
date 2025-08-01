using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    private void OnEnable()
    {
        this.ReBorn();
    }

    protected override void OnDead()
    {
        this.DespawnEnemy();
    }

    protected virtual void DespawnEnemy()
    {
        WaveManager.Instance.enemyCount--;
        LeanPool.Despawn(transform.parent);
    }
}
