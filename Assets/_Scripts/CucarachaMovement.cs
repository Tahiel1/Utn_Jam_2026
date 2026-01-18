using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CucarachaMovement : MonoBehaviour
{
    [SerializeField] private Light2D the_light;
    private float speedMov=0f;
    private float movOn = 200f;
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
            Debug.LogWarning("No se encontro una luz");
    }
    void FixedUpdate()
    {
        if (seeLight())
        {
            speedMov = movOn;
            cucaMoveForward();
        }
        else
        {
            speedMov = movOff;
            cucaStop();
        }
    }

    private bool seeLight()
    {
        if (the_light.intensity == 1)
        {
            anim.speed = 1f;
            return true;
        }
        else
        {
            anim.speed = 0f;
            return false;
        }
    }

    private void cucaMoveForward()
    {
        Vector2 direction = transform.up;
        m_Rigidbody.AddForce(direction * speedMov * Time.deltaTime);
    }
    private void cucaStop()
    {
        m_Rigidbody.linearVelocity = Vector2.zero;
    }
}
