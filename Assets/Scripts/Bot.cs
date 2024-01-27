using UnityEngine;

public class Bot : Participant
{
    bool isActionTime;

    private void Update()
    {
        if (isActionTime)
        {
            ((BotDeck)myDeck).RandomAttack();

            PassMyTurn();
            isActionTime = false;
        }
    }

    protected override void TurnLogic()
    {
        isActionTime = true;
    }
}
