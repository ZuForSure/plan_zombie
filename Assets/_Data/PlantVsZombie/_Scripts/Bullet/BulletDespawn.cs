using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDis
{
    public override void DespawnObj()
    {
        //BulletManager.Instance.DespawnToPool(transform.parent);

        LeanPool.Despawn(transform.parent.gameObject);
    }
}
