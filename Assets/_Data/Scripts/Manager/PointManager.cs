using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : ZuMonoBehaviour
{
    protected static PointManager instance;
    public static PointManager Instance => instance;

    [SerializeField] protected List<Transform> points;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 PointManager");
        PointManager.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoint();
    }

    protected virtual void LoadPoint()
    {
        if (this.points.Count > 0) return;

        foreach (Transform child in transform)
        {
            this.points.Add(child);
        }
        Debug.Log(transform.name + ": LoadPoint", gameObject);
    }

    public virtual Transform GetRandomPoint()
    {
        int random = Random.Range(0, points.Count);
        return this.points[random];
    }
}
