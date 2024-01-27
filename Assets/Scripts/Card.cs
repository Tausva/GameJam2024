using Assets.Scripts.Enums;
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
    [SerializeField] private List<Tag> tags;

    [Space]
    //Lerping vars
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timeElapsed;
    [SerializeField] private float lerpDuration = 3;

    private void Awake()
    {
        jokeText = GetComponentInChildren<TMP_Text>();
        tagContainer = transform.GetChild(1).GetChild(1);
    }

    private void Update()
    {
        if (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
    }

    public Card InstantiateCard(string windup, string punchline, List<Tag> tags)
    {
        jokePunchline = punchline;
        jokeWindup = windup;
        this.tags = tags;

        UpdateVisuals();

        return this;
    }

    public bool PenetratesShield(Tag tag)
    {
        return tags.Contains(tag);
    }

    public void DisableBack()
    {
        var back = transform.GetChild(0);
        back.gameObject.SetActive(false);
    }

    public void MoveToPosition(Vector2 position)
    {
        targetPosition = position;
        startPosition = transform.position;
        timeElapsed = 0;
    }

    //Right now only adds visuals, dont remove tags!
    private void UpdateVisuals()
    {
        jokeText.text = jokeWindup;

        AddTags();
    }

    private void AddTags()
    {
        foreach (var tag in tags)
        {
            var instantiatedTag = Instantiate(tagPrefab);
            instantiatedTag.GetComponent<TagLogic>().SetImage(tag);
            instantiatedTag.transform.SetParent(tagContainer);
        }
    }
}
