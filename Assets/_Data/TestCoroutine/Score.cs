using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : ZuSingleton<Score>
{
    [SerializeField] protected int score = 0;
    public int _Score => score; 

    public virtual void AddScore(int amount)
    {
        this.score += amount;
    }

}
