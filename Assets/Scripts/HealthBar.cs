using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        private bool IsPlayer;
        [SerializeField] GameObject winLoosePanel;

        private void Awake()
        {
        }

        void Start()
        {
        }

        void Update()
        {
        }

        public void DamageHealthBar(bool isPlayer)
        {
            var slider = GetComponent<Slider>();
            slider.value -= 1;
            
            IsPlayer = isPlayer;
        }

        public void CheckWhoWin()
        {
            var slider = GetComponent<Slider>();

            if (!IsPlayer && slider.value == 0)
            {
                winLoosePanel.SetActive(true);
                var text = winLoosePanel.transform.GetChild(0).GetComponent<TMP_Text>();
                text.enabled = true;
                text.enableKerning = true;
                text.SetText("You Loose");
                AudioManager.StopPlaying();
                AudioManager.PlaySound(2);
            }

            if (IsPlayer && slider.value == 0)
            {
                winLoosePanel.SetActive(true);
                var text = winLoosePanel.transform.GetChild(0).GetComponent<TMP_Text>();
                text.enabled = true;
                text.enableKerning = true;
                text.SetText("You win");
                AudioManager.StopPlaying();
                AudioManager.PlaySound(1);
            }
        }
    }
}
