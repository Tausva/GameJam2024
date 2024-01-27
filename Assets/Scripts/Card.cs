using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    private TMP_Text jokeText;
    private Transform tagContainer;

    [SerializeField] private GameObject tagPrefab;

    [Space]
    [Header("Debug")]
    [SerializeField] private string jokeWindup;
    [SerializeField] private string jokePunchline;
    [SerializeField] private List<string> tags;



    private void Awake()
    {
        jokeText = GetComponentInChildren<TMP_Text>();
        tagContainer = transform.GetChild(1);
    }

    public Card InstantiateCard(string windup, string punchline, List<string> tags)
    {
        jokePunchline = punchline;
        jokeWindup = windup;
        this.tags = tags;

        UpdateVisuals();

        return this;
    }

    public bool PenetratesShield(string tag)
    {
        return tags.Contains(tag);
    }

    //Right now only adds visuals, dont remove tags!
    private void UpdateVisuals()
    {
        jokeText.text = jokeWindup;

        AddTags();
    }

    private void AddTags()
    {
        foreach (string tag in tags)
        {
            var instantiatedTag = Instantiate(tagPrefab);
            //Do tag logic: instantiatedTag.GetComponent<>
            instantiatedTag.transform.parent = tagContainer;
        }
    }
}
