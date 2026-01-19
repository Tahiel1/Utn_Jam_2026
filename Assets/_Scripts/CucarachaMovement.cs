using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CucarachaMovement : MonoBehaviour
{
    [SerializeField] private Light2D the_light;
    private float speedMov=0f;
    [SerializeField] private float movOn = 2f;
    private float movOff = 0f;
    private Rigidbody2D m_Rigidbody;
    [SerializeField] private Animator anim;

    void Start()
    {
        //encontrar mi  rigidbody
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Encuntrar la animación
        anim=gameObject.GetComponent<Animator>();
        //Encontrar luz
        GameObject find_light = GameObject.FindWithTag("light");
        if (find_light != null)
            the_light = find_light.GetComponent<Light2D>();
        else
            Debug.LogWarning("No se encontr� una luz");
    }
    void FixedUpdate()
    {
        cucaMoveForward();
    }
    private void Update()
    {
        seeLight();
    }

    private void seeLight()
    {
        if (the_light.intensity == 1)
        {
            speedMov = movOn;
            anim.speed = 1f;
        }
        else
        {
            speedMov = movOff;
            anim.speed = 0f;
        }
    }

    private void cucaMoveForward()
    {
        Vector2 direction = transform.up;
        m_Rigidbody.linearVelocity = direction * speedMov;
    }
}
