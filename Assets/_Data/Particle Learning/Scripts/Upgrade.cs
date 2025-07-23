using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _ps;
    [SerializeField] protected Level level;
    [SerializeField] protected float radius = 1f;

    private void Awake()
    {
        this._ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        this.BuffRadius();
    }

    protected virtual void BuffRadius()
    {
        this.CheckLevel();
        this.UpdateParticleRadius();
    }

    protected virtual void CheckLevel()
    {
        if (this.level == Level.level1) this.radius = 1f;
        if (this.level == Level.level2) this.radius = 2f; 
        if (this.level == Level.level3) this.radius = 5f; 
    }

    protected virtual void UpdateParticleRadius()
    {
        var shape = this._ps.shape;
        shape.radius = this.radius;
    }
}
