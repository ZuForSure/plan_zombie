using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantAbstract : ZuMonoBehaviour
{
    [Header("Plant Abstract")]
    [SerializeField] protected PlantCtrl plantCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlantCtrl();
    }

    protected virtual void LoadPlantCtrl()
    {
        if (this.plantCtrl != null) return;
        this.plantCtrl = transform.GetComponentInParent<PlantCtrl>();
        Debug.Log(transform.name + ": LoadPlantCtrl", gameObject);
    }
}
