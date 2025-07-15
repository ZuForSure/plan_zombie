using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHP : ZuMonoBehaviour
{
    [SerializeField] protected string HP;
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
        this.HP = GameManager.Instance.gameHP.ToString();
        this.textMP.text = "HP: " + this.HP;
    }
}
