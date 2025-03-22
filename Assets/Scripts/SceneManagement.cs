using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("StartingScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
