using Assets;
using Assets.Scripts.Enums;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    private TMP_Text jokeText;
    private Transform tagContainer;

    [SerializeField] private GameObject tagPrefab;

    private string jokeWindup;
    private string jokePunchline;
    private List<Tag> tags;
    private AttackGenerator attackGenerator;
    private Deck deck;

    //Lerping vars
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timeElapsed;
    [Space]
    [SerializeField] private float lerpDuration = 3;

    private bool attackInProgress = false;
    private bool disableInitiated = false;
    private bool actionTaken = false;

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

        if (disableInitiated && !actionTaken)
        {
            actionTaken = true;
            deck.FinishMove(attackInProgress);
        }
    }

    public void AddAttackGenerator(AttackGenerator attackGenerator)
    {
        this.attackGenerator = attackGenerator;
    }

    public void AddDeck(Deck deck)
    {
        this.deck = deck;
    }

    public void CallAttackGenerator()
    {
        attackInProgress = attackGenerator.ClaculateDamage(tags, jokePunchline);
        AudioManager.PlaySound(7);
    }

    public Card InstantiateCardShell(string windup, string punchline, List<Tag> tags)
    {
        jokePunchline = punchline;
        jokeWindup = windup;
        this.tags = tags;

        return this;
    }

    public Card InstantiateCard(string windup, string punchline, List<Tag> tags)
    {
        jokePunchline = punchline;
        jokeWindup = windup;
        this.tags = tags;

        UpdateVisuals();

        return this;
    }

    public List<Tag> GetTagsUsedCard()
    {
        return tags;
    }

    public void DisableBack()
    {
        var back = transform.GetChild(0);
        back.gameObject.SetActive(false);
    }

    public void DisableCards()
    {
        deck.ToggleHand(false);
    }

    public void RemoveAllCards()
    {
        disableInitiated = true;

        DisableCards();
        transform.parent.parent.GetComponent<Hand>().RemoveAllCards();
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
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
