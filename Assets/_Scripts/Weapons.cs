using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapons : MonoBehaviour
{
    private Camera Cam;
    private  Vector2 mousePos;
    [SerializeField]private int SpeedPointer;

    private void Start()
    {
        Cam = Camera.main;
    }

    private void Update()
    {
        Vector2 MouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = MouseWorldPoint - (Vector2)transform.position;
        transform.up = Vector2.MoveTowards(transform.up, position, SpeedPointer * Time.deltaTime);


    }
}
