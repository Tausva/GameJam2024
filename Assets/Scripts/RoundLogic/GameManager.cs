using Assembly_CSharp;
using System.Collections;
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
    [SerializeField] private Deck playerDeck;

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
            isPlayerTurn = false;
            shieldGeneratorBot.RotateShieldForGame();
            bot.EnableTurn();
        }
        else
        {
            isPlayerTurn = true;
            shieldGeneratorPlayer.RotateShieldForGame();

            StartCoroutine(SpawnCards());

            player.EnableTurn();
        }
    }

    private bool DecideWhoGoesFirst()
    {
        return true;
    }

    private IEnumerator SpawnCards()
    {
        float waitFor = 0.3f;

        playerDeck.DrawCard();
        yield return new WaitForSeconds(waitFor);

        playerDeck.DrawCard();
        yield return new WaitForSeconds(waitFor);

        playerDeck.DrawCard();
        yield return new WaitForSeconds(waitFor);

        playerDeck.DrawCard();
    }
}
