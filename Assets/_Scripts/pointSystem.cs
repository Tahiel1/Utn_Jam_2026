using TMPro;
using UnityEngine;

public class pointSystem : MonoBehaviour
{
    [SerializeField] private GameObject pointSystemOb;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private int currentPoints=0;
    [SerializeField] private int pointsToAdd=10;
    [SerializeField] private int pointsToSubtract=5;
    private void Start()
    {
        pointText = pointSystemOb.GetComponent<TextMeshProUGUI>();
        pointText.text = currentPoints.ToString();
    }
    public void AddPoints()
    {
        currentPoints += pointsToAdd;
        pointText.text = currentPoints.ToString();
    }
    public void SubtractPoints()
    {
        currentPoints -= pointsToSubtract;
        pointText.text = currentPoints.ToString();
    }
}
