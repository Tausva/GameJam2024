using Assets.Scripts.Enums;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private bool isMyTurn = false;
    private GameManager gameManager;

    //Testing
    public Transform pregab;
    public Transform prego;

    public void EnableTurn()
    {
        isMyTurn = true;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {
        var cardTrans = Instantiate(pregab, prego);
       var card = cardTrans.GetComponent<Card>();
        card.InstantiateCard("Bober kurwa", "jak perdole", new List<Tag> { Tag.Fire, Tag.Water, Tag.Dragon, Tag.Demon, Tag.Bug});
    }
}
