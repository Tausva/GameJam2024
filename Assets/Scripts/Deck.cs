using Assets;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private Hand hand;
    private CardGenerator generator;
    [SerializeField] private AttackGenerator attackGenerator;

    [Space]
    [SerializeField] private GameObject cardPrefab;

    private void Awake()
    {
        generator = GetComponent<CardGenerator>();
    }

    public void ToggleHand(bool isEnabled)
    {
        hand.ToggleCards(isEnabled);
    }

    public void DrawCard()
    {
        var cardObj = Instantiate(cardPrefab, transform);
        generator.GetCard(cardObj.GetComponent<Card>());
        cardObj.GetComponent<Card>().AddAttackGenerator(attackGenerator);
        cardObj.GetComponent<Card>().AddDeck(this);
        hand.PlaceNewCard(cardObj.transform);
    }
}
