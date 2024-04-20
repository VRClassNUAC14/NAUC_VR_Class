using UnityEngine;

[RequireComponent(typeof(Light))]                // Ensure we have a light
public class OnTrigger_Light : MonoBehaviour     // Name of the class and script
{
    Light myLight;                               // Declaring a variable 
    void Start()
    {
        myLight = GetComponent<Light>();         // Assigning a variable
    }
    private void OnTriggerEnter(Collider other)  // When my trigger is hit
    {
        if (other.name.Contains("Controller"))   // and what hit me name has 'Controller'
        {
            FlipLightSwitch();                   // call FlipLightSwitch()
        }
    }
    private void FlipLightSwitch()
    {
        if (myLight.enabled)                     // If my light is on turn it off
        {
            myLight.enabled = false;
        }
        else
        {
            myLight.enabled = true;              // Otherwise, turn it on
        }
    }
}
