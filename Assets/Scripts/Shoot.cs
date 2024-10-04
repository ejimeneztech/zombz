using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode fireKey = KeyCode.Mouse0;
    public Camera playerCam;
    public float damageAmount = 25f;
    public string zombieTag = "Zombie";

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            ShootRay();
        }
    }

    private void ShootRay()
    {
        // Shoot ray from reticle/camera
        Ray ray = playerCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            HandleRaycastHit(hitInfo);
        }
        else
        {
            Debug.Log("No target hit");
        }
    }

    private void HandleRaycastHit(RaycastHit hitInfo)
    {
        GameObject target = hitInfo.collider.gameObject;
        Debug.Log($"Hit {target.name}");

        if (target.CompareTag(zombieTag))
        {
            DealDamage(target);
        }
    }

    private void DealDamage(GameObject target)
    {
        ZombieHealth zombieHealth = target.GetComponent<ZombieHealth>();

        if (zombieHealth != null)
        {
            zombieHealth.TakeDamage(damageAmount);
            Debug.Log($"Zombie Health: {zombieHealth.currentHealth}");
        }
    }
}
