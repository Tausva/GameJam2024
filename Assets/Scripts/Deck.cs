using Assets;
using UnityEngine;
using UnityEngine.Events;

public class Deck : MonoBehaviour
{
    [SerializeField] private Hand hand;
    private CardGenerator generator;
    [SerializeField] protected AttackGenerator attackGenerator;

    [Space]
    [SerializeField] private GameObject cardPrefab;

    private UnityEvent actionCompleteEvent;

    private void Awake()
    {
        generator = GetComponent<CardGenerator>();
    }

    public void SubscribeToActionCompleteEvent(UnityAction listener)
    {
        if (actionCompleteEvent == null)
            actionCompleteEvent = new UnityEvent();

        actionCompleteEvent.AddListener(listener);
    }

    public void ToggleHand(bool isEnabled)
    {
        hand.ToggleCards(isEnabled);

        if (!isEnabled)
        {
            actionCompleteEvent.Invoke();
        }
    }

    public void DrawCard()
    {
        var cardObj = Instantiate(cardPrefab, transform);
        generator.GetCard(cardObj.GetComponent<Card>());
        cardObj.GetComponent<Card>().AddAttackGenerator(attackGenerator);
        cardObj.GetComponent<Card>().AddDeck(this);
        hand.PlaceNewCard(cardObj.transform);
        AudioManager.PlaySound(4);

    }
}
