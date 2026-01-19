using TMPro;
using UnityEngine;

public class pointSystem : MonoBehaviour
{
    [SerializeField] private GameObject pointSystemOb;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private int currentPoints=0;
    [SerializeField] private int pointsToAdd=10;
    [SerializeField] private int lifes;
    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;
    private void Start()
    {
        lifes= 3;
        pointText = pointSystemOb.GetComponent<TextMeshProUGUI>();
        pointText.text = currentPoints.ToString();
    }
    public void AddPoints()
    {
        currentPoints += pointsToAdd;
        pointText.text = currentPoints.ToString();
        lifes++;
        showsLife(lifes);
    }
    public void SubtractLife()
    {
        lifes--;
        showsLife(lifes);
    }

    public void showsLife(int lifes)
    {
        switch (lifes)
        {
            case 3:
                life3.SetActive(true);
                life2.SetActive(true);
                life1.SetActive(true);
                break;
            case 2:
                life3.SetActive(false);
                life2.SetActive(true);
                life1.SetActive(true);
                break;
            case 1:
                life3.SetActive(false);
                life2.SetActive(false);
                life1.SetActive(true);
                break;
            case 0:
                life3.SetActive(false);
                life2.SetActive(false);
                life1.SetActive(false);
                break;
            default:
                life3.SetActive(true);
                life2.SetActive(true);
                life1.SetActive(true);
                break;
        }
    }
}
