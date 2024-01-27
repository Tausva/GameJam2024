using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    private readonly System.Random random = new System.Random();

    private void Awake()
    {

    }

    void Start()
    {
        var getRandomTags = GetRandomTags();
        AddImagesToCard(getRandomTags);
    }

    void Update()
    {

    }

    private List<Tag> GetRandomTags()
    {
        var luckChance = random.Next(1, 10);
        var tags = new List<Tag>();

        int countOfTags;

        if(luckChance  >= 9)
        {
            countOfTags = 5;
            tags = GetRandomTagsNumber(countOfTags);
        }
        else if(luckChance >= 5)
        {
            countOfTags = 4;
            tags = GetRandomTagsNumber(countOfTags);
        }
        else 
        {
            countOfTags = random.Next(2, 3);
            tags = GetRandomTagsNumber(countOfTags);
        }

        return CheckAndReplace(tags);
    }

    private List<Tag> GetRandomTagsNumber(int countOfTags)
    {
        var categories = new List<Tag>();

        var jokeCategories = Enum.GetValues(typeof(Tag));

        for (int i = 0; i < countOfTags; i++)
        {
            var randomCategory = (Tag)jokeCategories.GetValue(random.Next(jokeCategories.Length));
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
                        tags[j] = (Tag)random.Next(0, 10);
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


    private void AddImagesToCard(List<Tag> tags)
    {

        foreach(Tag tag in tags)
        {
            switch (tag)
            {
                case Tag.Fire:
                    Debug.Log("It is Fire");
                    break;
                case Tag.Water:
                    Debug.Log("It's a water tag!");
                    break;
                case Tag.Air:
                    Debug.Log("It's an air tag!");
                    break;
                case Tag.Forest:
                    Debug.Log("It's a forest tag!");
                    break;
                case Tag.Bug:
                    Debug.Log("It's a bug tag!");
                    break;
                case Tag.Fairy:
                    Debug.Log("It's a fairy tag!");
                    break;
                case Tag.Dragon:
                    Debug.Log("It's a dragon tag!");
                    break;
                case Tag.Wizard:
                    Debug.Log("It's a wizard tag!");
                    break;
                case Tag.Witch:
                    Debug.Log("It's a witch tag!");
                    break;
                case Tag.Demon:
                    Debug.Log("It's a demon tag!");
                    break;
                case Tag.Angel:
                    Debug.Log("It's an angel tag!");
                    break;
                default:
                    Debug.Log("Unknown tag!");
                    break;
            }
        }
       
    }
  
    
}
