using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamSender : DamageSender
{
    [Header("Bullet Dam Sender")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    //public float bulletDamage;

    //protected override void OnEnable()
    //{
    //    base.OnEnable();
    //    this.damage = this.bulletDamage;
    //}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.GetComponentInParent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.SendDamageToObject(collision.transform);
        this.DespawnBullet();
    }

    protected virtual void DespawnBullet()
    {
        if (this.bulletCtrl.BulletDespawn == null) return;
        this.bulletCtrl.BulletDespawn.DespawnObj();
    }
}
