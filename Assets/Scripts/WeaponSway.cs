using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float swayAmount = 0.05f;
    public float smoothFactor = 4f;
    public float maxSwayAmount = 0.1f;

    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {   //set to initial pos of the weapon
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse movement inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Calculate the target sway pos based on mouse movement
        Vector3 targetPosition = new Vector3(-mouseX * swayAmount, -mouseY * swayAmount, 0);

        // Clamp the position to avoid excessive swaying
        targetPosition.x = Mathf.Clamp(targetPosition.x, -maxSwayAmount, maxSwayAmount);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -maxSwayAmount, maxSwayAmount);

        // Smoothly transition to the target sway position
        // Use Time.deltaTime to ensure frame rate independence
        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + targetPosition, Time.deltaTime * smoothFactor);
    }
}
