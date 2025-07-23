using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void Start()
    {
        //for override
    }

    protected virtual void Update()
    {
        //for override
    }

    protected virtual void LoadComponent()
    {
        //for override
    }

    protected virtual void ResetValue()
    {
        //for override
    }
}
