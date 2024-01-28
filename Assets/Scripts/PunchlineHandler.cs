using TMPro;
using UnityEngine;

public class PunchlineHandler : MonoBehaviour
{
    private TMP_Text text;
    private Animator animator;

    void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        animator = GetComponent<Animator>();
    }

    public void ShowPunchline(string punchline)
    {
        animator.SetTrigger("Punch");
        text.text = punchline;
    }
}
