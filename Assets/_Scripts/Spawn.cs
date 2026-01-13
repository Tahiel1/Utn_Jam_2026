using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Insect;
    [SerializeField] private  Vector2 MinSpawn;
    [SerializeField] private  Vector2 MaxSpawn;

    float PositionX;
    float PositionY;

    private float halfMax;
    private float halfMin;

    private int CantInstct;


    Vector2 SpawnLocation;


    private void Start()
    {
    }

    private void Update()
    {
        CantInstct = GameObject.FindGameObjectsWithTag("Insect").Length; // Cantidad de insectos

        SpawnInsect();

        Debug.Log("Posicion del insecto" + SpawnLocation + "Cantidad de instectos:" + CantInstct);
    }

    void SpawnInsect() // Metodo para spawnear insectos
    {
        halfMax = MaxSpawn.x / 2;

        float CyMax = transform.position.y;
        float CxMax = transform.position.x;

        float MaxX = UnityEngine.Random.Range(CxMax - halfMax, CxMax + halfMax);
        float MaxY = UnityEngine.Random.Range(CyMax - halfMax, CyMax + halfMax);

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
            Vector3 SpawnLocation = new Vector3(MaxX, MaxY, 0);
            Instantiate(Insect, SpawnLocation, quaternion.identity);
        }
        else
        {
            Debug.Log("Maximo de insectos alcanzado");
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
