using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class DragPlant : ZuMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject plantPrefab;
    public PlantCtrl plantCtrl;
    public Tilemap targetTilemap;

    public GameObject draggingIcon;
    public Canvas canvas;

    protected override void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //GameObject newPlant = PlantSpawner.Instance.SpawnPrefab(this.plantPrefab.transform, transform.position, transform.rotation).gameObject;
        //newPlant.SetActive(true);

        GameObject newPlant = LeanPool.Spawn(this.plantPrefab, transform.position, transform.rotation);
        draggingIcon = newPlant;
        draggingIcon.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingIcon != null)
        {
            draggingIcon.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!EnoughCoin()) return;

        if (draggingIcon != null)
        {

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 100;

            //Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            Vector3Int cellPos = targetTilemap.WorldToCell(worldPos);
            Vector3 snappedWorldPos = targetTilemap.GetCellCenterWorld(cellPos);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null && hit.CompareTag("DropArea"))
            {
                //GameObject newPlant = PlantSpawner.Instance.SpawnPrefab(this.plantPrefab.transform, snappedWorldPos, Quaternion.identity).gameObject;
                
                LeanPool.Spawn(this.plantPrefab, snappedWorldPos, Quaternion.identity);
            }

            //PlantSpawner.Instance.DespawnToPool(draggingIcon.transform);
            //draggingIcon = null;
            LeanPool.Despawn(this.draggingIcon);
        }
    }

    protected virtual bool EnoughCoin()
    {
        return ScoreManager.Instance.DeductCoin(this.plantCtrl.plantCost);
    }
}
