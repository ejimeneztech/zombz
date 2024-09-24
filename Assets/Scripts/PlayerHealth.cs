using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        Debug.Log(currentHealth);
    }

    

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0) 
        {
            Destroy(gameObject);
            Debug.Log("You Died.");
        }

    }
}
