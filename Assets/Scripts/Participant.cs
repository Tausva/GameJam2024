using UnityEngine;

public class Participant : MonoBehaviour, IPlayer
{
    private bool isMyTurn = false;
    private GameManager gameManager;
    [SerializeField] protected Deck myDeck;

    public void EnableTurn()
    {
        isMyTurn = true;
        TurnLogic();
    }

    public void Instantiate(GameManager manager)
    {
        gameManager = manager;
    }

    public void PassMyTurn()
    {
        if (isMyTurn)
        {
            isMyTurn = false;
            gameManager.PassTurn();
        }
    }

    protected virtual void TurnLogic()
    {
    }
}