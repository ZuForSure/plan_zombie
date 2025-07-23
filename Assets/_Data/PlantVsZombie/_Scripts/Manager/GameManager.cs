using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]

public class GameManager : ZuSingleton<GameManager>
{
    public bool isGameOver = false;

    public GameObject gameover;
    public GameObject victory;

    public int gameHP = 5;
    public int maxGameHP = 5;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGameOverANdWIn();
    }

    protected override void Update()
    {
        base.Update();
        this.CheckIsVictory();
    }

    protected virtual void LoadGameOverANdWIn()
    {
        if (this.gameover != null) return;
        this.gameover = GameObject.Find("Game Over");
        this.victory = GameObject.Find("Victory");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameHP--;
        //EnemySpawner.Instance.DespawnToPool(collision.transform.parent);

        LeanPool.Despawn(collision.transform.parent);
        if (this.gameHP <= 0) this.GameOver();
    }

    public virtual void GameOver()
    {
        this.isGameOver = true;
        Time.timeScale = 0;
        this.gameover.SetActive(true);
    }

    public virtual void Victory()
    {
        this.isGameOver = false;
        Time.timeScale = 0;
        this.victory.SetActive(true);
    }

    protected virtual void CheckIsVictory()
    {
        if (WaveManager.Instance.WaveCount > WaveManager.Instance.FinalWave)
        {
            if (WaveManager.Instance.enemyCount > 0) return;
            if (this.gameHP <= 0) return;

            this.Victory();
        }
    }
}
