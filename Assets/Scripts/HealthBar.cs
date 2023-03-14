using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        public Slider slider;
        [SerializeField]
        public Color low;
        [SerializeField]
        public Color high;
        [SerializeField]
        public Vector3 offset;

        public void setHealth(float health, float maxHealth)
        {
            slider.gameObject.SetActive(health < maxHealth);
            slider.value = health;
            slider.maxValue = maxHealth;
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
        }

        // Start is called before the first frame update
        void Start()
        {
            slider.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        }
    }
}
