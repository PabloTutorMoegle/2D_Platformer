using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformsController : MonoBehaviour
{
    private MovementSystem _mv;
    private Tilemap tilemap;
    public bool isBreakable = true;
    public bool isMoving = false;
    public Vector3 moveDirection = Vector3.right;
    public float speed = 2f;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        TryGetComponent<MovementSystem>(out _mv);
    }

    private void Start()
    {
        if(isMoving)
        {
            _mv.MoveLinearVelocity(moveDirection, speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable && collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            ContactPoint2D contact = collision.GetContact(0);

            Vector3Int cell = tilemap.WorldToCell(contact.point);

            if (!tilemap.HasTile(cell))
            {
                cell = tilemap.WorldToCell(
                    contact.point + (Vector2)contact.normal * 0.025f
                );
            }

            if (tilemap.HasTile(cell))
                tilemap.SetTile(cell, null);
        }
        if(isMoving)
        {
            if (moveDirection == Vector3.right)
            {
                moveDirection = Vector3.left;
            }
            else if (moveDirection == Vector3.left)
            {
                moveDirection = Vector3.right;
            }
        }
    }
}
