using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        private bool IsPlayer;
        [SerializeField] GameObject winLoosePanel;

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
                ActivatePanel("You have lost!", 2);
            }

            if (IsPlayer && slider.value == 0)
            {
                StartCoroutine(DelayVictory());
            }
        }

        private IEnumerator DelayVictory()
        {
            float waitFor = 3f;
            yield return new WaitForSeconds(waitFor);

            ActivatePanel("Victory!", 1);
        }

        private void ActivatePanel(string text, int soundId)
        {
            winLoosePanel.SetActive(true);
            var textField = winLoosePanel.transform.GetChild(0).GetComponent<TMP_Text>();
            textField.SetText(text);
            AudioManager.StopPlaying();
            AudioManager.PlaySound(soundId);
        }
    }
}
