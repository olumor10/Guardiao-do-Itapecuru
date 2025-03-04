using UnityEngine;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Pontos: " + playerScore;
    }
}
