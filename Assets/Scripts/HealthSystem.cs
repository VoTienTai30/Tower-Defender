using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public TextMeshProUGUI txt_healthCount;
    public int defaultHealthCount;
    public int healthCount;
    public GameObject LoseScreen;

    public void Init()
    {
        healthCount = defaultHealthCount;
        txt_healthCount.text = healthCount.ToString();
    }

    public void LoseHealth()
    {
        healthCount--;
        txt_healthCount.text = healthCount.ToString();
        if (healthCount < 1)
        {
            LoseScreen.SetActive(true);
            return;
        }
        CheckHealthCount();
    }

    void CheckHealthCount()
    {
        if (healthCount < 1)
        {
            Debug.Log("You lost");
        }
    }
   
}
