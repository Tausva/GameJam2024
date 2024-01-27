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

    public void DrawCard()
    {
        var cardObj = Instantiate(cardPrefab, transform);
        generator.GetCard(cardObj.GetComponent<Card>());
        cardObj.GetComponent<Card>().AddAttackGenerator(attackGenerator);
        hand.PlaceNewCard(cardObj.transform);
    }
}
