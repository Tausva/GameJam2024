using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assembly_CSharp
{
    public class ShieldGenerator : MonoBehaviour
    {
        private readonly System.Random Random = new System.Random();

        private List<Tag> Shields = new List<Tag>();

        private void Awake()
        {
            Shields = GetShieldTags();
        }

        void Start()
        {
        }

        void Update()
        {
        }

        public Tag GetRoundDefenseShield()
        {
            return Shields.First();
        }

        public void RotateShieldForGame()
        {
            Shields = RotateShield(Shields);
        }

        private List<Tag> GetShieldTags()
        {
            var shieldTags = GetRandomTagsNumber(3);

            return CheckAndReplace(shieldTags);
        }

        private List<Tag> RotateShield(List<Tag> tags)
        {
            var rotatedTags = new List<Tag>(tags.Count);
            rotatedTags.Add(tags[tags.Count - 1]);

            for (int i = 0; i < tags.Count - 1; i++)
            {
                rotatedTags.Add(tags[i]);
            }

            return rotatedTags;
        }

        private List<Tag> GetRandomTagsNumber(int countOfTags)
        {
            var categories = new List<Tag>();

            var jokeCategories = Enum.GetValues(typeof(Tag));

            for (int i = 0; i < countOfTags; i++)
            {
                var randomCategory = (Tag)jokeCategories.GetValue(Random.Next(jokeCategories.Length));
                categories.Add(randomCategory);
            }

            return categories;
        }

        private List<Tag> CheckAndReplace(List<Tag> tags)
        {
            while (HasDuplicates(tags))
            {
                for (int i = 0; i < tags.Count; i++)
                {
                    for (int j = i + 1; j < tags.Count; j++)
                    {
                        if (tags[i] == tags[j])
                        {
                            tags[j] = (Tag)Random.Next(0, 10);
                        }
                    }
                }
            }

            return new List<Tag>(tags);
        }

        private bool HasDuplicates(List<Tag> tags)
        {
            return tags.GroupBy(x => x).Any(g => g.Count() > 1);
        }


    }
}
