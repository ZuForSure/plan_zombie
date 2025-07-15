using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : BulletAbstract
{
    [Header("Bullet Fly")]
    [SerializeField] protected float flySpeed = 7f;
    [SerializeField] protected Vector3 flyDirection = Vector3.right;

    //protected override void Update()
    //{
    //    base.Update();
    //    this.Flying();
    //}

    //protected virtual void Flying()
    //{
    //    transform.parent.Translate(this.flyDirection * this.flySpeed * Time.deltaTime);
    //}

    private void FixedUpdate()
    {
        this.Flying();
    }

    protected virtual void Flying()
    {
        transform.parent.Translate(this.flyDirection * this.flySpeed * Time.fixedDeltaTime);
    }
}
