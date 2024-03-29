using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void ChangeLanguage(int languageId)
    {
        PlayerPrefs.SetInt("Language", languageId);
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
