using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ZuMonoBehaviour
{
    [SerializeField] protected Rigidbody2D e_rb;
    public Rigidbody2D E_rb => e_rb;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.e_rb != null) return;
        this.e_rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody2D", gameObject);
    }
}
