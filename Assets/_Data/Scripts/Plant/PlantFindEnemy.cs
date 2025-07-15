using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFindEnemy : ZuMonoBehaviour
{
    [SerializeField] protected float shootingRange = 20f;
    [SerializeField] protected int plantLayer = 3;
    [SerializeField] protected int areaLayer = 7;
    [SerializeField] protected int bitMaskNotHitted;
    [SerializeField] protected Vector3 raycastDirection = Vector3.right;
    [SerializeField] protected bool isFindEnemy = false;
    [SerializeField] protected bool isDrawRaycast = false;
    public bool IsFindEnemy => isFindEnemy;

    protected override void Update()
    {
        base.Update();
        this.EnemyFinding();
    }

    protected virtual void EnemyFinding()
    {
        this.IgnoreLayer();
        Vector3 pos = transform.position;
        RaycastHit2D hitEnemy = Physics2D.Raycast(pos, this.raycastDirection, this.shootingRange, this.bitMaskNotHitted);

        if (hitEnemy.collider == null)
        {
            this.isFindEnemy = false;
            return;
        }

        Debug.Log(hitEnemy.transform.name);
        this.isFindEnemy = true;

        if (!this.isDrawRaycast) return;
        Debug.DrawLine(pos, new Vector3(pos.x + this.shootingRange, pos.y, 0f), Color.green);
    }

    protected virtual void IgnoreLayer()
    {
        this.bitMaskNotHitted = ~((1 << this.plantLayer) | (1 << this.areaLayer));
    }
}
