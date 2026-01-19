
using UnityEngine;
using UnityEngine.InputSystem;




public class Weapons : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = 10f; // distancia a la cámara

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
