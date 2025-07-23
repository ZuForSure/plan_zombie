using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ZuMonoBehaviour
{
    [SerializeField] protected GameObject melee;
    [SerializeField] protected float attackSpeed = 1.5f;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float attackRange = 0.5f;
    [SerializeField] protected int enemyLayer = 6;
    [SerializeField] protected int gameLayer = 8;
    [SerializeField] protected Vector2 direc = Vector2.left;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMelee();
    }

    protected virtual void LoadMelee()
    {
        if (this.melee != null) return;
        this.melee = transform.GetChild(0).gameObject;
        this.melee.SetActive(false);
        Debug.Log(transform.name + ": LoadMelee", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.FindPlant();
    }

    protected virtual void FindPlant()
    {
        Vector3 pos = transform.position;
        RaycastHit2D hitPlant = Physics2D.Raycast(pos, this.direc, this.attackRange, ~((1 << this.enemyLayer) | (1<<this.gameLayer)));
        
        if (hitPlant.collider == null) return;
        this.Attack();

        Debug.DrawLine(pos, new Vector3(pos.x + this.attackRange * this.direc.x, pos.y, 0f), Color.red);
    }

    protected virtual void Attack()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.attackSpeed) return;
        this.timer = 0f;

        this.melee.SetActive(true);
        StartCoroutine(this.DespawnAttack());
    }

    protected IEnumerator DespawnAttack()
    {
        yield return new WaitForSeconds(0.1f);
        this.melee.SetActive(false);
    }
}
