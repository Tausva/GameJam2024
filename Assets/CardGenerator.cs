using Assembly_CSharp;
using Assets;
using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    private readonly System.Random Random = new System.Random();
    private readonly Repository Repository = new Repository();

    private Dictionary<string, string> Jokes = new Dictionary<string, string>();

    private void Awake()
    {
        GetDadeJokesInLithuania();
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void GetCard(Card card)
    {
        var randomJoke = GetRandomKeyValuePair();

        card.InstantiateCard(randomJoke.Key, randomJoke.Value, GetRandomTags());
    }

    public void GetDadeJokesInEnglish()
    {
        Jokes = Repository.GetJokesByLanguage(LanguageJoke.English);
    }

    public void GetDadeJokesInLithuania()
    {
        Jokes = Repository.GetJokesByLanguage(LanguageJoke.Lithuania);
    }

    private List<Tag> GetRandomTags()
    {
        var luckChance = Random.Next(1, 10);
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
            countOfTags = Random.Next(2, 3);
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

    private KeyValuePair<string, string> GetRandomKeyValuePair()
    {
        int index = Random.Next(Jokes.Count);

        return Jokes.ElementAt(index);
    }
}
