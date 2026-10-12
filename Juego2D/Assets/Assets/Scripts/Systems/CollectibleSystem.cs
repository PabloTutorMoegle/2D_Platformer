using UnityEngine;

public class CollectibleSystem : MonoBehaviour
{
    public string collectibleType;
    public int amount = 1;
    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<InventorySystem>(out InventorySystem _pi))
        {
            Debug.Log("Collected");
            _pi.AddItem(collectibleType, amount, icon);
            Destroy(gameObject);
        }
    }
}
