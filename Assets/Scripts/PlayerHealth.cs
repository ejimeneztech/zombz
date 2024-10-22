using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float currentHealth;

    // health bar
    public Image healthBarFill;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        UpdateHealthBar();
        
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, health); // Clamp to prevent negative health
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {

            healthBarFill.gameObject.SetActive(false); 
            Destroy(gameObject);
            Debug.Log("You Died.");
        }
    }

    private void UpdateHealthBar()
    {

        healthBarFill.fillAmount = currentHealth / health; // Update the health bar fill amount
       
    }
}
