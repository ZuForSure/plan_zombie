using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : ZuSingleton<SpawnManager>
{
    public GameObject[] prefabs;

    public virtual GameObject SpawnPrefabByName(string name,Vector3 pos, Quaternion rot)
    {
        foreach (var prefab in prefabs)
        {
            if (prefab.name != name) continue;
            return LeanPool.Spawn(prefab, pos, rot);
        }

        return null;
    }

    //public virtual GameObject SpawnPrefab(string name, Vector3 pos, Quaternion rot)
    //{
    //    foreach (var prefab in prefabs)
    //    {
    //        if (prefab.name != name) continue;
    //        return LeanPool.Spawn(prefab, pos, rot);
    //    }

    //    return null;
    //}
}
