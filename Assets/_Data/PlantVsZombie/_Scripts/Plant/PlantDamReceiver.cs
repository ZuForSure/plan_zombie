using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDamReceiver : DamageReceiver
{
    private void OnEnable()
    {
        this.ReBorn();
    }

    protected override void OnDead()
    {
        this.DespawnPlant();
    }

    protected virtual void DespawnPlant()
    {
        LeanPool.Despawn(transform.parent);
    }
}
