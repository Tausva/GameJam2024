using UnityEngine;

public class Player : Participant
{
    protected override void TurnLogic()
    {
        myDeck.ToggleHand(true);
        myDeck.SubscribeToActionCompleteEvent(PassMyTurn);
    }
}
