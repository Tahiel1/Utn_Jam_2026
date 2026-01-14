using UnityEngine;
using UnityEngine.Rendering.Universal;
public class killOnClick : MonoBehaviour
{
    [SerializeField] private Light2D the_light;
    private float turnedOn = 1f;

    private void Start()
    {
        GameObject find_light = GameObject.FindWithTag("light");
        if (find_light != null)
            the_light = find_light.GetComponent<Light2D>();
        else
            Debug.LogWarning("No se encontro una luz");
    }
    void OnMouseDown()
    {
        if (the_light.intensity == turnedOn)
            Destroy(gameObject);
    }
}
