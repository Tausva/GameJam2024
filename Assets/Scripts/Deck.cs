using Assets;
using System.Collections;
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
    }

    public void FinishMove(bool delay)
    {
        if (delay)
        {
            StartCoroutine(DelayTurn());
        }
        else
        {
            actionCompleteEvent.Invoke();
        }
    }

    private IEnumerator DelayTurn()
    {
        float waitFor = 3f;
        yield return new WaitForSeconds(waitFor);

        actionCompleteEvent.Invoke();
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
