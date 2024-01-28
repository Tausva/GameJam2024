using TMPro;
using UnityEngine;

public class PunchlineHandler : MonoBehaviour
{
    private TMP_Text text;
    private GameObject panel;

    void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        panel = transform.GetChild(0).gameObject;
        panel.SetActive(false);
    }

    public void ShowPunchline(string punchline)
    {
        panel.SetActive(true);
        text.text = punchline;
    }
}
