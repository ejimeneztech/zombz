using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public GameObject inventoryScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isActive = inventoryScreen.activeSelf;
            inventoryScreen.SetActive(!isActive);

            // Pause/unpause game
            Time.timeScale = isActive ? 1f : 0f;

            // Optional: lock/unlock cursor
            //Cursor.lockState = isActive ? CursorLockMode.Locked : CursorLockMode.None;
            //Cursor.visible = !isActive;
        }
    }
}
