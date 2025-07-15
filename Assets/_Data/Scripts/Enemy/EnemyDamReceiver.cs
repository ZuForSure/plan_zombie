using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        Debug.Log("Enemy DEAD");
    }
}
