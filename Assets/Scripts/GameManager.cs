using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public Text scoreText;
    public Text lives;
    public GameObject egg, rottenEgg, basket;
    public GameObject bottomBorder;

    public int Lives;
    public int CurrentScore;
    private float ySpawn = 5.5f;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 3.0f;
    public float rottenEggProbability = 0.2f;

    private float spawnTimer = 0f;
    private float spawnInterval;
    private float speed = 50.0f;

    private void Awake()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        lives.text = "Lives: " + Lives.ToString();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * speed * Time.deltaTime;
        basket.transform.position += new Vector3(movement, 0f, 0f);
    }

    void FixedUpdate()
    {
        spawnTimer += Time.fixedDeltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnEgg();
            spawnTimer = 0f;
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void spawnEgg()
    {
        float xSpawn = Random.Range(-8.0f, 8.0f);
        Vector3 spawnPosition = new Vector3(xSpawn, ySpawn, 0f);
        GameObject eggToSpawn = (Random.value < rottenEggProbability) ? rottenEgg : egg;
        Instantiate(eggToSpawn, spawnPosition, Quaternion.identity);
    }

    public void AddScore()
    {
        CurrentScore++;
        if (RuntimeScoreManager.Instance == null)
        {
            Debug.LogError("RuntimeScoreManager instance is null. Make sure it's in the scene.");
            return;
        }
        RuntimeScoreManager.Instance.HighScore = System.Math.Max(CurrentScore,RuntimeScoreManager.Instance.HighScore);
        scoreText.text = "Score: " + CurrentScore.ToString();
    }


    public void deductLife()
    {
        Lives--;
        lives.text = "Lives: " + Lives.ToString();

        if (Lives <= 0)
        {
            Debug.Log("Game Over!");
            RuntimeScoreManager.Instance.CurrentScore = CurrentScore;
            SceneManager.LoadScene("Gameover");
        }
    }
}
