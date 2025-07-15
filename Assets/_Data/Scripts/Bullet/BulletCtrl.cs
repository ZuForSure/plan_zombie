using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ZuMonoBehaviour
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }
}
