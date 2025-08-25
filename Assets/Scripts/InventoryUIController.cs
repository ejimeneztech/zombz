using UnityEngine;
using StarterAssets;

public class InventoryUIController : MonoBehaviour
{
    public GameObject inventoryScreen;
    public GameObject reticle;
    public FirstPersonController fpsController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reticle.SetActive(true);
        inventoryScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isActive = inventoryScreen.activeSelf;
            bool newState = !isActive;

            inventoryScreen.SetActive(newState);
            reticle.SetActive(!newState); // reticle is opposite of inventory state

            Time.timeScale = newState ? 0f : 1f;

            //Disable Camera Movement
            fpsController.enabled = !newState;

            // Optional: lock/unlock cursor
            Cursor.lockState = newState ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = newState;
        }

    }
}
