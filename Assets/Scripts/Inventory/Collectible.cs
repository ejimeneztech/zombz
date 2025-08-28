using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Sprite itemIcon;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectItem(itemIcon);
                Destroy(gameObject);
            }

        }
    }
}
