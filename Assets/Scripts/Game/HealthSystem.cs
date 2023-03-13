using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public TMP_Text txt_healthCount;
    public int defaultHealthCount;
    public int healthCount;

    public void Init()
    {
        healthCount = defaultHealthCount;
        txt_healthCount.text = healthCount.ToString();
    }

    public void LoseHealth()
    {
        if (healthCount < 1) return;
        healthCount--;
        txt_healthCount.text = healthCount.ToString();
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
