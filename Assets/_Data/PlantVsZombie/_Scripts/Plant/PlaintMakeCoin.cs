using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaintMakeCoin : PlantAbstract
{
    [SerializeField] protected int coinPerTime = 50;
    [SerializeField] protected float cooldown = 5f;
    [SerializeField] protected float timer = 0;

    protected override void Update()
    {
        base.Update();
        this.MakeCoin();
    }

    protected virtual void MakeCoin()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.cooldown) return;
        this.timer = 0f;

        this.AddCoinToShop();
    }

    protected virtual void AddCoinToShop()
    {
        ScoreManager.Instance.AddCoin(this.coinPerTime);
    }
}
