using System.Collections;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public KeyCode fireKey = KeyCode.Mouse0;
    public Camera playerCam;
    public float damageAmount = 25f; //can go in weapon script
    public string zombieTag = "Zombie";

    //ammo
    public int maxAmmo = 25;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;


    
    public float recoilRotationAmount = 0.2f; //amount of recoil to apply
    public float recoilReturnSpeed = 5f;  //speed at which recoil returns
    public Transform gunTransform;     // gun transform

    private Quaternion originalGunRotation;   //store original position of gun

    public ParticleSystem flashVFX;

    void Start()
    {
        currentAmmo = maxAmmo;
        updateAmmoUI();
        originalGunRotation = gunTransform.localRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(fireKey) && currentAmmo > 0)
        {
            ShootRay();
            ApplyRecoil();
            playMuzzleFlashVFX();
            currentAmmo -= 1;
            updateAmmoUI();
            
        }

        ResetRecoil();
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


    void ApplyRecoil()
    {
        gunTransform.localRotation *= Quaternion.Euler(0, 0, -recoilRotationAmount);
    }

    void ResetRecoil()
    {
        gunTransform.localRotation = Quaternion.Lerp(gunTransform.localRotation, originalGunRotation, Time.deltaTime * recoilReturnSpeed);
    }

    void updateAmmoCount(int currentAmmo)
    {

    }

    void updateAmmoUI()
    {
        ammoText.text = $"{currentAmmo}/{maxAmmo}";
    }

    void playMuzzleFlashVFX()
    {
        flashVFX.Play();
    }
}
