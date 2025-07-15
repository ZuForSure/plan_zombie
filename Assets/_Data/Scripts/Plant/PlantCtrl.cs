using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCtrl : ZuMonoBehaviour
{
    [SerializeField] protected PlantFindEnemy plantFindEnemy;
    public PlantFindEnemy PlantFindEnemy => plantFindEnemy;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlantFindEnemy();
    }

    protected virtual void LoadPlantFindEnemy()
    {
        if (this.plantFindEnemy != null) return;
        this.plantFindEnemy = transform.GetComponentInChildren<PlantFindEnemy>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }
}
