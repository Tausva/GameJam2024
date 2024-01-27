using UnityEngine;

public class Bot : Participant
{
    bool isTurnOver;

    private void Update()
    {
        if (isTurnOver)
        {
            PassMyTurn();
            isTurnOver = false;
        }
    }

    protected override void TurnLogic()
    {
        Debug.Log("Bot turn");
        isTurnOver = true;
    }
}
