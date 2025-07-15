using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        this.DespawnEnemy();
    }

    protected virtual void DespawnEnemy()
    {
        EnemySpawner.Instance.DespawnToPool(transform.parent);
    }
}
