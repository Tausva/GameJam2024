using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        private void Awake()
        {
        }

        void Start()
        {
        }

        void Update()
        {
        }

        public void DamageHealthBar()
        {
            var slider = GetComponent<Slider>();
            slider.value -= 1; 
        }
    }
}
