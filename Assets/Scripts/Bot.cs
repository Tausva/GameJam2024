using UnityEngine;

public class Bot : Participant
{
    bool isMyTurn;

    private void Update()
    {
        if (isMyTurn)
        {
            ((BotDeck)myDeck).RandomAttack();

            PassMyTurn();
            isMyTurn = false;
        }
    }

    protected override void TurnLogic()
    {
        isMyTurn = true;
    }
}
