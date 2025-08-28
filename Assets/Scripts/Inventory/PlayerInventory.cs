using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public int collectedItems = 0;
    public TextMeshProUGUI countText;

    [Header("UI Slots")]
    public List<Image> inventorySlots; // Drag your slot images here
    public Sprite emptySlotSprite; // Placeholder for empty

    public int selectedSlotIndex = -1;



    void Start()
    {
        updateCountUI();
    }


    public void CollectItem(Sprite itemIcon)
    {
        //Increase counter
        collectedItems++;
        updateCountUI();
        Debug.Log($"Collected item #{collectedItems}, sprite = {itemIcon}");

        //Add item icon to first empty slot
        foreach (Image slot in inventorySlots) 
        {
            if (slot.sprite == emptySlotSprite || slot.sprite == null) // Slot is empty
            {
                slot.sprite = itemIcon;
                slot.color = Color.white;
                Debug.Log("Placed item in slot!");
                break;
            }
        }

    }

    void updateCountUI()
    {
        countText.text = $"{collectedItems}/3";
    }

    //Use Item
    public void UseItem()
    {
        if(selectedSlotIndex >= 0 && selectedSlotIndex < inventorySlots.Count)
        {
            Debug.Log($"Using item in slot {selectedSlotIndex}");
        }
    }

    //Move Item
    public void MoveItem()
    {
        Debug.Log("Move item - not implemented yet");
    }

    //Discard Item
    public void DiscardItem()
    {
        Debug.Log($"Discarding item in slot {selectedSlotIndex}");
        inventorySlots[selectedSlotIndex].sprite = emptySlotSprite;
        
    }
}
