using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _ps;
    [SerializeField] protected Animator ani;
    [SerializeField] protected Level level;
    [SerializeField] protected float size = 1f;

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
        if (this.level == Level.level1) 
        {
            this.ani.SetTrigger("isChange1");
            this.size = 1f;
        }

        if (this.level == Level.level2) 
        {
            this.ani.SetTrigger("isChange2");
            this.size = 2f;
        }

        if (this.level == Level.level3)
        {
            this.ani.SetTrigger("isChange3");
            this.size = 3f;
        }
    }

    protected virtual void UpdateParticleRadius()
    {
        var mainModule = this._ps.main;
        mainModule.startSize = this.size;
    }
}
