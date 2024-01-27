using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private bool isMyTurn = false;
    private GameManager gameManager;
    [SerializeField] private Deck myDeck;

    public void EnableTurn()
    {
        isMyTurn = true;
        myDeck.ToggleHand(true);
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
}
