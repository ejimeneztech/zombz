using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float lightDecay = .1f;
    public float angleDecay = 1f;
    public float minumumAngle = 40f;

    Light mylight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mylight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseAngle();
        DecreaseIntensity();
    }


    void DecreaseAngle()
    {
        if(mylight.spotAngle <= minumumAngle)
        {
            return;
        }
        mylight.spotAngle -= angleDecay * Time.deltaTime;
        
    }

    void DecreaseIntensity()
    {
        mylight.intensity -= lightDecay * Time.deltaTime;


    }
}
