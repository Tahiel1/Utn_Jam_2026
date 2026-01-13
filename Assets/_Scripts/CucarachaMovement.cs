using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CucarachaMovement : MonoBehaviour
{
    [SerializeField] private Light2D the_light;
    private float speed=0f;
    private Rigidbody2D m_Rigidbody;
    void Start()
    {
        //encontrar mi  rigidbody
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Encontrar luz
        GameObject find_light = GameObject.FindWithTag("light");
        if (find_light != null)
            the_light = find_light.GetComponent<Light2D>();
        else
            Debug.LogWarning("No se encontr� una luz");
    }
    void FixedUpdate()
    {
        Vector2 direction = transform.up;
        m_Rigidbody.linearVelocity = direction * speed;
    }
    private void Update()
    {
        if (the_light.intensity == 1)
            speed = 2f;
        else
            speed = 0f;
    }
}
