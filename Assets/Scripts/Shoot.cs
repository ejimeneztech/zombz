using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode fireKey = KeyCode.Mouse0;
    public Transform gunPoint;

    public float fireRange = 100f;
    public float damageAmount = 25f;

    public string zombieTag = "Zombie";

   
    

    void OnDrawGizmos()
    {
        if (gunPoint != null)
        {
            Gizmos.color = Color.red;  // Set the gizmo color to red
            Gizmos.DrawRay(gunPoint.position, -gunPoint.right * fireRange);  // Draw the ray in the scene
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(gunPoint.position, -gunPoint.right * fireRange, Color.red, 1.0f);

        if (Input.GetKeyDown(fireKey))
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(gunPoint.position, -gunPoint.right, out hitInfo, fireRange))
            {
                GameObject target = hitInfo.collider.gameObject;
                if (target.CompareTag(zombieTag))
                {
                    //Deal damage to zombie
                    ZombieHealth zombieHealth = target.GetComponent<ZombieHealth>();
                    if (zombieHealth != null) 
                    {
                        zombieHealth.TakeDamage(damageAmount);
                        Debug.Log(zombieHealth.currentHealth);
                    }
                    Debug.Log("Hit Target");
                }
                else
                {
                    Debug.Log("No Hit");
                }

            } 
            
        }
    }





}
