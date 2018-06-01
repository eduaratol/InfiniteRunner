using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}