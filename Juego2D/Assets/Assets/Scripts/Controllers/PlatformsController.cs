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
        Debug.Log("Collision");
        if (isBreakable)
        {    
            ContactPoint2D contact = collision.GetContact(0);

            Vector3 hitPosition = contact.point - contact.normal * 0.025f;

            Vector3Int cellPosition =
                tilemap.WorldToCell(hitPosition);

            if (tilemap.HasTile(cellPosition))
            {
                tilemap.SetTile(cellPosition, null);
            }
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
