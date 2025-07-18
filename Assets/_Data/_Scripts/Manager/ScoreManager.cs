using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : ZuSingleton<ScoreManager>
{
    public int coin = 0;

    public virtual void AddCoin(int mount)
    {
        this.coin += mount;
    }

    public virtual bool DeductCoin(int mount) 
    {
        if (!CanDeduct(this.coin, mount)) return false;
        this.coin -= mount;
        return true;
    }

    protected virtual bool CanDeduct(int scoreType, int amout)
    {
        if (amout > scoreType) return false;
        if (scoreType <= 0) return false;
        return true;
    }
}
