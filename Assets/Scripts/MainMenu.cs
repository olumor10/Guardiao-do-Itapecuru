using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // Nome da cena do jogo
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        // Debug.Log("Quitting game...");
        Application.Quit();
    }
}
