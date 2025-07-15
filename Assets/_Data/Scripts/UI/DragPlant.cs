using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class DragPlant : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject plantPrefab;
    public PlantCtrl plantCtrl;
    public Tilemap targetTilemap;

    public GameObject draggingIcon;
    public Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject newPlant = PlantSpawner.Instance.SpawnPrefab(this.plantPrefab.transform, transform.position, transform.rotation).gameObject;
        newPlant.SetActive(true);

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

            Vector3Int cellPos = targetTilemap.WorldToCell(worldPos);
            Vector3 snappedWorldPos = targetTilemap.GetCellCenterWorld(cellPos);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null && hit.CompareTag("DropArea"))
            {
                GameObject newPlant = PlantSpawner.Instance.SpawnPrefab(this.plantPrefab.transform, snappedWorldPos, Quaternion.identity).gameObject;
                newPlant.SetActive(true);
            }

            PlantSpawner.Instance.DespawnToPool(draggingIcon.transform);
        }
    }

    protected virtual bool EnoughCoin()
    {
        return ScoreManager.Instance.DeductCoin(this.plantCtrl.plantCost);
    }

    private Vector3 SnapToGrid(Vector3 pos)
    {
        float cellSize = 2f;
        float x = Mathf.Floor(pos.x / cellSize) * cellSize + cellSize / 2;
        float y = Mathf.Floor(pos.y / cellSize) * cellSize + cellSize / 2;
        return new Vector3(x, y, 0);
    }
}
