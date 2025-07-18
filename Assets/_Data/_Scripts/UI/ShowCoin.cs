using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCoin : ZuMonoBehaviour
{
    [SerializeField] protected string coin;
    [SerializeField] protected TextMeshProUGUI textMP;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadText();
    }

    protected virtual void LoadText()
    {
        if (this.textMP != null) return;
        this.textMP = transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ":LoadText ", gameObject);
    }

    protected override void Update()
    {
        this.ShowCoinToUI();
    }

    protected virtual void ShowCoinToUI()
    {
        this.coin = ScoreManager.Instance.coin.ToString();
        this.textMP.text =  "Coin: "  + this.coin; 
    }
}
