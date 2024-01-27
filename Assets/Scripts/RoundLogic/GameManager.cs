using Assembly_CSharp;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPlayerTurn;
    private bool isPlayerStartedFirst;
    private int roundNumber;

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private GameObject botGameObject;
    [SerializeField] private ShieldGenerator shieldGeneratorPlayer;
    [SerializeField] private ShieldGenerator shieldGeneratorBot;

    private IPlayer player;
    private IPlayer bot;

    private void Start()
    {
        isPlayerTurn = DecideWhoGoesFirst();
        isPlayerStartedFirst = isPlayerTurn;
        roundNumber = 0;

        player = playerGameObject.GetComponent<IPlayer>();
        bot = botGameObject.GetComponent<IPlayer>();

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
            shieldGeneratorBot.RotateShieldForGame();
        }
        else
        {
            player.EnableTurn();
            isPlayerTurn = true;
            shieldGeneratorPlayer.RotateShieldForGame();
            
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
