using System;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Insect;

    [SerializeField] DestroyInsect destroiInsect;

    [SerializeField] private Vector2 MinSpawn;
    [SerializeField] public Vector2 MaxSpawn;

    Vector3 DirectionInsect;
    Vector3 SpawnLocation;

    private float QuaternionInsect;

    private float CyMax;
    private float CxMax;

    private float MaxX;
    private float MaxY;

    private float halfMax;
    private float halfMin;

    public int CantInstct;

    private float TimerSpawn = 0;
    [SerializeField] private float intervalSpawn = 2f;

    private void Start()
    {
    }

    private void Update()
    {
        CantInstct = GameObject.FindGameObjectsWithTag("Insect").Length; // Cantidad de insectos


        TimerSpawn += +Time.deltaTime;
        if (TimerSpawn >= intervalSpawn)
        {
            SpawnInsect();
            TimerSpawn = 0;
        }


        Debug.Log("Cantidad de instectos:" + CantInstct);
    }

    void SpawnInsect() // Metodo para spawnear insectos
    {
        halfMax = MaxSpawn.x / 2;

         CyMax = transform.position.y;
         CxMax = transform.position.x;

         MaxX = UnityEngine.Random.Range(CxMax - halfMax, CxMax + halfMax);
         MaxY = UnityEngine.Random.Range(CyMax - halfMax, CyMax + halfMax);

        halfMin = MinSpawn.x / 2;

        float CyMinPositive = transform.position.y + halfMin;
        float CxMinPositive = transform.position.x + halfMin;

        float CyMinNegative = transform.position.y - halfMin;
        float CxMinNegative = transform.position.x - halfMin;


            if (MaxX > CxMinNegative && MaxX < CxMinPositive && MaxY > CyMinNegative && MaxY < CyMinPositive) // Verifica que la ubicacion no este dentro del area minima
            {
                Debug.Log("Ubicacion no permitida");
            }
            else if (CantInstct <= 10)
            {
                DirectionInsect = destroiInsect.transform.position - SpawnLocation;
                QuaternionInsect = Mathf.Atan2(DirectionInsect.y, DirectionInsect.x) * Mathf.Rad2Deg;
                Quaternion RotationInsect = Quaternion.Euler(0, 0, QuaternionInsect);
                SpawnLocation = new Vector3(MaxX, MaxY, 0);
                //Instantiate(Insect, SpawnLocation, RotationInsect);
                Instantiate(Insect, transform.position, RotationInsect);
            }
            else
            {
                Debug.Log("Maximo de insectos alcanzado");
            }
            TimerSpawn = 0;
    }  
    

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Insect"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, MinSpawn);


        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, MaxSpawn);

    }

}
