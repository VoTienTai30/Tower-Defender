using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public TextMeshProUGUI txt_Currency;
    public int defaultCurrency;
    public int currency;

    private Timer timer;
    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5;
        timer.run();
    }

    private void Update()
    {
        if(timer.Finished)
        {
            Gain(1);
            timer.Duration = 5;
            timer.run();
        }
    }

    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }
    public void Gain(int val)
    {
        currency += val;
        UpdateUI();
    }
    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currency -= val;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool EnoughCurrency(int val)
    {
        if (val <= currency)
            return true;
        else
            return false;
    }
    void UpdateUI()
    {
        txt_Currency.text = currency.ToString();
    }

    public void USE_TEST()
    {
        Debug.Log(Use(3));
    }

}
