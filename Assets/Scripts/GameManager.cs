using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("GameManager instance created");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        //Debug.Log("Game Over triggered");
        PlayerPrefs.SetInt("PlayerScore", ScoreManager.instance.GetScore());
        SceneManager.LoadScene("GameOver"); // Nome da sua cena de game over
    }
}
