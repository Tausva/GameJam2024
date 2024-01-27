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
        [SerializeField] HealthBar healthBarBot;

        private void Awake()
        {
        }

        void Start()
        {
        }

        void Update()
        {
        }

        public void ClaculateDamage(List<Tag> cardTags)
        {
            var isDamageShouldBeMade = false;
            var shieldTag = shieldGenerator.GetRoundDefenseShield();

            Debug.Log(shieldTag.ToString());

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
                healthBarBot.DamageHealthBar();
            }
        }
    }
}
