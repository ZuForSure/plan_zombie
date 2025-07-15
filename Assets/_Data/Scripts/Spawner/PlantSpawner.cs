using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : Spawner
{
    protected static PlantSpawner instance;
    public static PlantSpawner Instance => instance;

    public static string shootPlant = "Shoot Plant";
    public static string coinPlat = "Coin Plant";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 bullet PlantSpawner allowed");
        PlantSpawner.instance = this;
    }
}
