using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager: MonoBehaviour
{
    Score score;
    public Text scoreDisplayer;
    void Start()
    {
        score = Resources.Load<Score>("ScoreData");
        scoreDisplayer.text = "Current Score: " + score.CurrentScore.ToString() + "\r\nHigh Score: " + score.HighScore.ToString();
    }
}