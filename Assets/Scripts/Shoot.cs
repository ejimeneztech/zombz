using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode fireKey = KeyCode.Mouse0;
    public Transform gunPoint;
    public float fireRange = 100f;
    public float damageAmount = 10f;
    public LayerMask targetLayerMask; //LayerMask to filter whwat can be hit

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
        Debug.DrawRay(gunPoint.position, gunPoint.forward * fireRange, Color.red, 1.0f);

        if (Input.GetKeyDown(fireKey))
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(gunPoint.position, gunPoint.forward, out hitInfo, fireRange))
            {
                GameObject target = hitInfo.collider.gameObject;
                Debug.Log("Hit Target");
            } 
            else
            {
                Debug.Log("No Hit");
            }
        }
    }
}
