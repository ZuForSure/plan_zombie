using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpanwer : Spawner
{
    protected static BulletSpanwer instance;
    public static BulletSpanwer Instance => instance;

    public static string Bullet = "Bullet";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 bullet spawner allowed");
        BulletSpanwer.instance = this;
    }
}
