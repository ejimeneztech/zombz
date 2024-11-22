using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int collectedItems = 0;
    public TextMeshProUGUI countText;
    
    void Start()
    {
        updateCountUI();
    }
    public void CollectItem()
    {
        collectedItems++;
        updateCountUI();
    }

    void updateCountUI()
    {
        countText.text = $"{collectedItems}/3";
    }
}
