using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float health = 100;
    public float currentHealth;
    private Animator zombieAnim;
    private float animTime;
    public float delay = 5f;


    private UnityEngine.AI.NavMeshAgent navAgent;

    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        zombieAnim = GetComponent<Animator>();
        animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            zombieAnim.SetBool("isWalking", false);
            zombieAnim.SetTrigger("Death_Trig");
            navAgent.isStopped = true;
            navAgent.velocity = Vector3.zero;
            
            Destroy(gameObject, animTime + delay);
            Debug.Log("Killed Zombie");
        }
    }

}
