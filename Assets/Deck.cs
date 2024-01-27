using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private Hand hand;
    private CardGenerator generator;

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
        hand.PlaceNewCard(cardObj.transform);
    }
}
