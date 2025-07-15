using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : ZuMonoBehaviour
{
    protected static ScoreManager instance;
    public static ScoreManager Instance => instance;

    public int coin = 0;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 bullet ScoreManager allowed");
        ScoreManager.instance = this;
    }
}
