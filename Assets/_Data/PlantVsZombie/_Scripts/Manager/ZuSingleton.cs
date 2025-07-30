using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuSingleton<T> : ZuMonoBehaviour where T : ZuMonoBehaviour
{
    protected static T instance;
    public static T Instance => instance;

    protected override void Awake()
    {
        this.LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance == null)
        {
            instance = this as T;
            //DontDestroyOnLoad(gameObject);
            return;
        }

        if (instance != this) Debug.LogError("Another instance of Singleton already exits");
    }
}
