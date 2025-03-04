using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
