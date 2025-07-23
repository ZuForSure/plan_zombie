using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : ZuMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObj();
    }

    public virtual void DespawnObj()
    {
        //for override
    }

    protected abstract bool CanDespawn();
}
