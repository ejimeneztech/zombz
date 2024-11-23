using UnityEngine;
using UnityEngine.SceneManagement;

public class Extract : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        //and if player
        if(other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if(playerInventory != null && playerInventory.collectedItems == 3)
            {
                SceneManager.LoadScene("WinScreen");
            } 
            
        }
    }
}
