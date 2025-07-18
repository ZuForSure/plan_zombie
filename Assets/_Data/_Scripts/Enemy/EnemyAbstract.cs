using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : ZuMonoBehaviour
{
    [Header("Enemy Abstract")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": EnemyCtrl", gameObject);
    }
}
