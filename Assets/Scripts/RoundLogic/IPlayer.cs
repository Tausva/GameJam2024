using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void EnableTurn();
    void Instantiate(GameManager manager);
}
