using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float currentHealth;

    // health bar
    public Image healthBarFill;

    //Cheat mode
    private bool unlimitedHealth  = false;
    private string cheatCode = "godmode";
    private string enteredCode = "";


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        UpdateHealthBar();
        
    }

    void Update()
    {
        CheckForCheatCode();
    }

    public void TakeDamage(float damageAmount)
    {
        if (unlimitedHealth) return;

        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, health); // Clamp to prevent negative health
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {

            healthBarFill.gameObject.SetActive(false); 
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateHealthBar()
    {

        healthBarFill.fillAmount = currentHealth / health; // Update the health bar fill amount
       
    }

    private void CheckForCheatCode()
    {
        foreach(char c in Input.inputString)
        {
            enteredCode += c;

            if (enteredCode.Length > cheatCode.Length)
                enteredCode = enteredCode.Substring(1);

            if (enteredCode.Equals(cheatCode))
            {
                ToggleUnlimitedHealth();
                enteredCode = "";
            }

        }
    }

    private void ToggleUnlimitedHealth()
    {
        unlimitedHealth = !unlimitedHealth; // Toggle cheat mode
        Debug.Log("Unlimited Health: " + (unlimitedHealth ? "Enabled" : "Disabled"));
    }
}
