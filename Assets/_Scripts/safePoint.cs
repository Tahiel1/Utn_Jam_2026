using TMPro;
using UnityEngine;

public class safePoint : MonoBehaviour
{
    [SerializeField] private GameObject pointSystem;
    private void OnTriggerExit2D(Collider2D collision)
    {
        pointSystem.GetComponent<pointSystem>().SubtractPoints();
    }
}
