using UnityEngine;

public class BotDeck : Deck
{
    [SerializeField] private CardGenerator cardGenerator;

    public void RandomAttack()
    {
        var card = new Card();
        cardGenerator.GetCardShell(card);

        attackGenerator.ClaculateDamage(card.GetTagsUsedCard(), "");
    }
}