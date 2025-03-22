using UnityEngine;

public class RuntimeScoreManager : MonoBehaviour
{
    public static RuntimeScoreManager Instance { get; set; }

    public int HighScore;
    public int CurrentScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
