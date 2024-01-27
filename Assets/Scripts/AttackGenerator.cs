using Assembly_CSharp;
using Assets.Scripts;
using Assets.Scripts.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class AttackGenerator : MonoBehaviour
    {
        [SerializeField] ShieldGenerator shieldGenerator;
        [SerializeField] HealthBar healthBar;
        [SerializeField] bool isPlayer;

        public void ClaculateDamage(List<Tag> cardTags)
        {
            var isDamageShouldBeMade = false;
            var shieldTag = shieldGenerator.GetRoundDefenseShield();

            foreach (var tag in cardTags)
            {
                if (shieldTag.Equals(tag))
                {
                    isDamageShouldBeMade = true;
                    break; 
                }
            }

            if (isDamageShouldBeMade)
            {
                healthBar.DamageHealthBar(isPlayer);

                if (isPlayer)
                {
                    AudioManager.PlaySound(6);
                }
                else
                {
                    AudioManager.PlaySound(5);
                }

                healthBar.CheckWhoWin();
            }
        }
    }
}
