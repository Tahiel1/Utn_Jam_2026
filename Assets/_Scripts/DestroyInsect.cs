using UnityEngine;

public class DestroyInsect : MonoBehaviour
{
    Spawn spawn;
    void Start()
    {
        spawn = UnityEngine.Object.FindFirstObjectByType<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = transform.position;

        if (p.x > spawn.MaxSpawn.x / 2f ||
            p.x < -spawn.MaxSpawn.x / 2f ||
            p.y > spawn.MaxSpawn.y / 2f ||
            p.y < -spawn.MaxSpawn.y / 2f)
        {
            spawn.CantInstct--;
            Destroy(gameObject);
        }
    }
}
