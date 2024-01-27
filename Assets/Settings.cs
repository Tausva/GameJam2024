using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown languageDropdown;

    void Start()
    {
        languageDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("Language", 1));
    }
}