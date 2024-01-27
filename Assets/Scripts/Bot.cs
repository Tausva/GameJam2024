using System.Collections;
using UnityEngine;

public class Bot : Participant
{
    [SerializeField] private Animator attackAnimator;

    bool isActionTime;

    private void Update()
    {
        if (isActionTime)
        {
            attackAnimator.SetTrigger("Attack");

            StartCoroutine(Attack());
            isActionTime = false;
        }
    }

    protected override void TurnLogic()
    {
        isActionTime = true;
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.2f);

        ((BotDeck)myDeck).RandomAttack();

        PassMyTurn();
    }
}
