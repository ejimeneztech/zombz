using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float health = 100;
    public float currentHealth;
    private Animator zombieAnim;
    private float animTime; //keeping track of the length of the animation
    private float delay = 7f; //This will be used to delay the destroy call
    private bool isDead = false;

    //to stop zombie from following the player when health is 0
    private UnityEngine.AI.NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        zombieAnim = GetComponent<Animator>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

    }

    public void TakeDamage(float damage)
    {
       if (isDead) return;

        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }



    void Die()
    {
        isDead = true;
        zombieAnim.SetBool("isWalking", false);
        zombieAnim.ResetTrigger("Attack_Trig");
        zombieAnim.SetTrigger("Death_Trig");

        //stop nav agent
        navAgent.isStopped = true;
        navAgent.velocity = Vector3.zero;

        GetComponent<AttackPlayer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        DestroyZombie();

    }


    public void DestroyZombie() 
    {
        Destroy(gameObject, animTime + delay);
    }
}
