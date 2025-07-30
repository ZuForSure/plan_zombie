using System.Collections;
using UnityEngine;

public class WaveManager : ZuSingleton<WaveManager>
{
    [Header("Wave Manager")]
    public bool isStartWave = false;
    public int enemyCount = 0;
    [SerializeField] protected bool isWaveDone = true;
    [SerializeField] protected float timeBetweenWaves = 7f;
    [SerializeField] protected float timeBetweenEnemies = 5f;
    [SerializeField] protected int maxEnemies = 5;
    [SerializeField] protected int newQuantityE = 5;
    [SerializeField] protected int waveCount = 0;
    [SerializeField] protected int finalWave = 3;
    public int WaveCount => waveCount;
    public int FinalWave => finalWave;

    protected override void Update()
    {
        base.Update();
        if (!this.CheckIsStartWave()) return;

        this.ChangeTimeBetweenE();
        this.Spawning();
    }

    protected virtual bool CheckIsStartWave()
    {
        if (GameManager.Instance.isGameOver) this.isStartWave = false;
        return this.isStartWave;
    }

    protected virtual void ChangeTimeBetweenE()
    {
        if (this.waveCount != this.finalWave) return;
        this.timeBetweenEnemies = 1.5f;
    }

    protected virtual void Spawning()
    {
        if (!this.isWaveDone) return;

        this.isWaveDone = false;
        StartCoroutine(this.WaveSpawner());
    }

    protected IEnumerator WaveSpawner()
    {
        this.isWaveDone = false;
        this.waveCount++;

        if (this.waveCount > this.finalWave)
        {
            this.isStartWave = false;
            yield break;
        }

        for (int i = 0; i < maxEnemies; i++)
        {
            this.SpawnEnemyAtRandomPoint();
            this.enemyCount++;
            yield return new WaitForSeconds(this.timeBetweenEnemies);
        }

        this.maxEnemies += this.newQuantityE;
        this.timeBetweenEnemies -= 1.5f;
        yield return new WaitForSeconds(this.timeBetweenWaves);

        this.isWaveDone = true;
    }

    protected virtual void SpawnEnemyAtRandomPoint()
    {
        Transform spawnPos = PointManager.Instance.GetRandomPoint();
        Quaternion spawnRot = Quaternion.identity;

        SpawnManager.Instance.SpawnPrefabByName("Enemy", spawnPos.position, spawnRot);
    }
}
