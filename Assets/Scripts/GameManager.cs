using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public Text scoreText;
    public Text lives;
    public GameObject egg,rottenEgg,basket;
    public GameObject bottomBorder;

    Score scoreObj;

    public int Lives;
    private float ySpawn = 5.5f;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 3.0f;

    public float rottenEggProbability = 0.2f;

    private float spawnTimer = 0f;
    private float spawnInterval;
    private float speed = 50.0f;

    private void Awake()
    {
        scoreObj = Resources.Load<Score>("ScoreData");
        spawnInterval = UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);
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
            spawnInterval = UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);
        }

    }
    void spawnEgg()
    {
        float xSpawn = UnityEngine.Random.Range(-8.0f, 8.0f);
        Vector3 spawnPosition = new Vector3(xSpawn, ySpawn, 0f);
        GameObject eggToSpawn = (UnityEngine.Random.value < rottenEggProbability) ? rottenEgg : egg;
        Instantiate(eggToSpawn, spawnPosition, Quaternion.identity);


    }
    public void AddScore()
    {
        scoreObj.CurrentScore++;
        scoreObj.HighScore=Math.Max(scoreObj.CurrentScore,scoreObj.HighScore);
        scoreText.text = "Score: " + scoreObj.CurrentScore.ToString();
    }
   public void deductLife()
    {
        Lives--;
        lives.text = "Lives: " + Lives.ToString();

        if (Lives <= 0)
        {
            Debug.Log("Game Over!");    
            SceneManager.LoadScene("Gameover");
        }
    }
}
