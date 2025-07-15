using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyAbstract
{
    [Header("Enemy Movement")]
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected Vector3 moveDirection = Vector3.left;

    private void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        Vector3 direction = this.moveDirection * Time.fixedDeltaTime * this.moveSpeed;
        this.enemyCtrl.E_rb.MovePosition(transform.parent.position + direction);
    }
}
