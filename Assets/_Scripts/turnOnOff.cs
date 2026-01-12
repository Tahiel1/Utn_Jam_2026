using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightToggler : MonoBehaviour
{
    public Light2D the_light;
    private float turnedOn = 1f;
    private float turnedOff = 0.01f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& the_light.intensity!=turnedOff)
            the_light.intensity = turnedOff;
        else if (Input.GetKeyDown(KeyCode.E) && the_light.intensity != turnedOn)
            the_light.intensity = turnedOn;
    }
}