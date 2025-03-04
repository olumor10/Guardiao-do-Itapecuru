using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene"); // Nome da sua cena do jogo
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Nome da sua cena do menu principal
    }
}
