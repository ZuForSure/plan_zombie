using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbleObj : ZuSingleton<SpawnAbleObj> 
{
    [SerializeField] protected List<GameObject> spawnAbleObjs;
    public List<GameObject> SpawnAbleObjs => spawnAbleObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.spawnAbleObjs.Count > 0) return;

        foreach (Transform child in this.transform)
        {
            this.spawnAbleObjs.Add(child.gameObject);
        }
        this.HidePrefab();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefab()
    {
        foreach (GameObject prefab in this.spawnAbleObjs)
        {
            prefab.SetActive(false);
        }
    }

    public virtual GameObject GetPrefabByName(string name)
    {
        foreach(GameObject prefab in this.spawnAbleObjs)
        {
            if (prefab.name != name) continue;
            return prefab;
        }

        return null;
    }
}
