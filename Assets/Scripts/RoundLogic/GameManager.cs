using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPlayerTurn;
    private bool isPlayerStartedFirst;
    private int roundNumber;

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject botGameObject;
    private IPlayer player;
    private IPlayer bot;

    private void Start()
    {
        isPlayerTurn = DecideWhoGoesFirst();
        isPlayerStartedFirst = isPlayerTurn;
        roundNumber = 1;

        player = playerGameObject.GetComponent<IPlayer>();
        //bot = botGameObject.GetComponent<IPlayer>();

        player.Instantiate(this);
        //bot.Instantiate(this);

        //Horrible hack
        isPlayerTurn = !isPlayerTurn;

        PassTurn();
    }

    public void PassTurn()
    {
        roundNumber += isPlayerStartedFirst == isPlayerTurn ? 0 : 1;

        if (isPlayerTurn)
        {
            //bot.EnableTurn();
            isPlayerTurn = false;
        }
        else
        {
            player.EnableTurn();
            isPlayerTurn = true;
        }

        Debug.Log(isPlayerTurn + " " + roundNumber);
    }

    void Update()
    {
        
    }

    private bool DecideWhoGoesFirst()
    {
        return true;
    }
}
