using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text scoreDisplayer;

    void Start()
    {
        int currentScore = RuntimeScoreManager.Instance.CurrentScore;
        int highScore = RuntimeScoreManager.Instance.HighScore;
        scoreDisplayer.text = "Current Score: " + currentScore + "\r\nHigh Score: " + highScore;
    }
}
