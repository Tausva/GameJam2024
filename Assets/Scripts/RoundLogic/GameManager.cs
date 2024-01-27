using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPlayerTurn;
    private bool isPlayerStartedFirst;
    private int roundNumber;

    [SerializeField] private IPlayer player;
    [SerializeField] private IPlayer bot;

    private void Start()
    {
        isPlayerTurn = DecideWhoGoesFirst();
        isPlayerStartedFirst = isPlayerTurn;
        roundNumber = 1;

        player.Instantiate(this);
        bot.Instantiate(this);

        //Horrible hack
        isPlayerTurn = !isPlayerTurn;

        PassTurn();
    }

    public void PassTurn()
    {
        roundNumber += isPlayerStartedFirst == isPlayerTurn ? 0 : 1;

        if (isPlayerTurn)
        {
            bot.EnableTurn();
            isPlayerTurn = false;
        }
        else
        {
            player.EnableTurn();
            isPlayerTurn = true;
        }
    }

    void Update()
    {
        
    }

    private bool DecideWhoGoesFirst()
    {
        return true;
    }
}
