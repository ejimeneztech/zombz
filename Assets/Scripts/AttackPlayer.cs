using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float damageAmount = 25f;
    private Animator zombieAnim;
    public string playerTag = "Player";

    void Start()
    {
        zombieAnim = GetComponent<Animator>();
        zombieAnim.SetBool("isWalking", true);
    }

    void OnTriggerEnter(Collider other)
    {
        //check if the collided object is the player
        if (other.CompareTag(playerTag))
        {

        }
        zombieAnim.SetTrigger("Attack_Trig");
        zombieAnim.SetBool("isWalking", false);
        
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        Debug.Log("Collision Detected");
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            zombieAnim.SetBool("isWalking", true);
        }
    }
    
}
