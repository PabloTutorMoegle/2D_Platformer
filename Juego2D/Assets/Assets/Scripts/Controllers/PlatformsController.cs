using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformsController : MonoBehaviour
{
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tilemap == null)
            return;

        ContactPoint2D contact = collision.GetContact(0);

        Vector3 hitPosition = contact.point - contact.normal * 0.025f;

        Vector3Int cellPosition =
            tilemap.WorldToCell(hitPosition);

        if (tilemap.HasTile(cellPosition))
        {
            tilemap.SetTile(cellPosition, null);
        }
    }
}
