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



    void Start()
    {
        updateCountUI();
    }


    public void CollectItem(Sprite itemIcon)
    {
        //Increase counter
        collectedItems++;
        updateCountUI();

        //Add item icon to first empty slot
        foreach (Image slot in inventorySlots) 
        {
            if (slot.sprite == emptySlotSprite) // Slot is empty
            {
                slot.sprite = itemIcon;
                slot.color = Color.white;
                break;
            }
        }

    }

    void updateCountUI()
    {
        countText.text = $"{collectedItems}/3";
    }
}
