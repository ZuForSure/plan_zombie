using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDamReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        this.DespawnPlant();
    }

    protected virtual void DespawnPlant()
    {
        PlantSpawner.Instance.DespawnToPool(transform.parent);
    }
}
