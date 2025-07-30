using Lean.Pool;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

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
        GameObject newPlant = SpawnManager.Instance.SpawnPrefabByName(transform.name, transform.position, transform.rotation);
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
                SpawnManager.Instance.SpawnPrefabByName(transform.name, snappedWorldPos, Quaternion.identity);
            }

            LeanPool.Despawn(this.draggingIcon);
        }
    }

    protected virtual bool EnoughCoin()
    {
        return ScoreManager.Instance.DeductCoin(this.plantCtrl.plantCost);
    }
}
